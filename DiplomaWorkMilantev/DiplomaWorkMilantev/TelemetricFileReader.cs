using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	public class TelemetricFileReader
	{
		BinaryReader reader;
		private bool isHeaderWasRead;
		private bool isSeansNameWasRead;

		public TelemetricFileReader(string filePath)
		{
			reader = new BinaryReader(new FileStream(filePath, FileMode.Open));
			reader.BaseStream.Seek(8, SeekOrigin.Begin);
		}

		public HeaderStruct ReadHeader()
		{
			byte[] headerBytes = reader.ReadBytes(40);
			HeaderStruct headStruct = (HeaderStruct)Marshal.PtrToStructure
				(Marshal.UnsafeAddrOfPinnedArrayElement(headerBytes, 0), typeof(HeaderStruct));
			isHeaderWasRead = true;
			return headStruct;
		}

		public string ReadSeansName()
		{
			if (!isHeaderWasRead)
				throw new InvalidReadingOrderException("Header wasn't read");

			isSeansNameWasRead = true;
			return System.Text.Encoding.Default.GetString(reader.ReadBytes(80));
		}

		public InfoBlockStruct ReadInfoStruct()
		{
			if (!isSeansNameWasRead)
				throw new InvalidReadingOrderException("Seans name wasn't read");

			return ReadStruct<InfoBlockStruct>
					((FileStream)reader.BaseStream, (int)reader.BaseStream.Position);
		}

		public byte[] ReadBytes(int count)
		{
			return reader.ReadBytes(count);
		}

		public static T ReadStruct<T>(FileStream fs, int from)
		{
			byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
			fs.Seek(from, SeekOrigin.Begin);
			for (int i = 0; i < buffer.Length; i++)
				buffer[i] = (byte)fs.ReadByte();

			GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			T temp = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
			handle.Free();
			return temp;
		}

	}
}
