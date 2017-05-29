using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	public class HexWord
	{
		byte[] bytes;

		public byte[] Bytes { get => bytes; set => bytes = value; }

		public HexWord(byte[] bytes)
		{
			if (bytes.Count() > 2)
				throw new ArgumentException(nameof(bytes));
			this.Bytes = bytes;
		}

		public HexWord(byte first, byte second)
		{
			Bytes = new byte[2];
			Bytes[0] = first;
			Bytes[1] = second;
		}

		public bool PutMask(int mask, int rightResult)
		{
			int wordInt = BitConverter.ToInt16(Bytes, 0);
			if ((wordInt & mask) == rightResult)
				return true;
			else
				return false;
		}

		public byte GetYoungerByte()
		{
			return Bytes[0];
		}

		public byte GetOlderByte()
		{
			return Bytes[1];
		}

		public override int GetHashCode()
		{
			return Bytes.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is HexWord))
				return false;
			return Bytes.Equals(((HexWord)obj).Bytes);
		}

		public override string ToString()
		{
			StringBuilder hex = new StringBuilder();
			foreach (byte b in Bytes)
				hex.AppendFormat("{0:x2}", b);
			return hex.ToString();
		}
	}
}
