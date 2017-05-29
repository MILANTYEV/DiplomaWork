using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
    class Program
    {
        static void Main(string[] args)
        {
			TelemetricFileReader reader = new TelemetricFileReader("1.tmi");
			HeaderStruct headStruct = reader.ReadHeader();
			int blocksCount = headStruct.InfoLength / headStruct.BufferLength;
			string seansName = reader.ReadSeansName();
			FramesSelector selector = new FramesSelector(0x03ff, 0x3ff);
			var frames = selector.SelectFrames(reader, blocksCount);
			
			Console.WriteLine("count of frames:{0}", frames.Count);

			IList<FrameData> framesDataList = FramesParser.GetFramesData(frames, 11, 1, 8, true);
			ICalibrator calibrator = new BoundaryLevelsCalibrator();
			calibrator.Calibrate(framesDataList);
			foreach (FrameData frameData in framesDataList)
				Console.WriteLine(frameData.ToString());

			Console.ReadKey();
		}
	}
}
