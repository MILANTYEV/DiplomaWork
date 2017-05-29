using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	[StructLayout(LayoutKind.Sequential, Pack =1)]
	public unsafe struct InfoBlockStruct
	{
		int titleLength;
		int infoLength;
		ushort bufferStatus;
		ushort timeCount;
		int timeType;
		int sec;
		int mSec;
		int countBuf;
		int countInt;
		//public fixed byte data[1024];

		public int TitleLength { get => titleLength; set => titleLength = value; }
		public int InfoLength { get => infoLength; set => infoLength = value; }
		public ushort BufferStatus { get => bufferStatus; set => bufferStatus = value; }
		public ushort TimeCount { get => timeCount; set => timeCount = value; }
		public int TimeType { get => timeType; set => timeType = value; }
		public int Sec { get => sec; set => sec = value; }
		public int MSec { get => mSec; set => mSec = value; }
		public int CountBuf { get => countBuf; set => countBuf = value; }
		public int CountInt { get => countInt; set => countInt = value; }
	}
}
