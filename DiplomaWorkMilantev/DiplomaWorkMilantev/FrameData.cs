using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	public class FrameData
	{
		private int _data;
		private int _seconds;
		private int _miliSeconds;

		public int Data { get => _data; set => _data = value; }
		public int Seconds { get => _seconds; set => _seconds = value; }
		public int MiliSeconds { get => _miliSeconds; set => _miliSeconds = value; }

		public FrameData(byte data, int seconds, int miliSeconds)
		{
			Data = data;
			Seconds = seconds;
			MiliSeconds = miliSeconds;
		}

		public override string ToString()
		{
			return string.Format("{0} {1}:{2}", Data, Seconds, MiliSeconds);
		}
	}
}
