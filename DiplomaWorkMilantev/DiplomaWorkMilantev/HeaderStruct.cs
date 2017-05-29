using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	[StructLayout(LayoutKind.Sequential)]
	public struct HeaderStruct
	{
		private int fileLength;
		private int titleLength;
		private double startTime;
		private double finalTime;
		private int infoLength;
		private int bufferLength;
		private int infoPos;
		private int closePos;

		public int FileLength { get => fileLength; set => fileLength = value; }
		public int TitleLength { get => titleLength; set => titleLength = value; }
		public double StartTime { get => startTime; set => startTime = value; }
		public double FinalTime { get => finalTime; set => finalTime = value; }
		public int InfoLength { get => infoLength; set => infoLength = value; }
		public int BufferLength { get => bufferLength; set => bufferLength = value; }
		public int InfoPos { get => infoPos; set => infoPos = value; }
		public int ClosePos { get => closePos; set => closePos = value; }
	}
}
