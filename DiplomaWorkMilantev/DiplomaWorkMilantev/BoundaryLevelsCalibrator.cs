using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	public class BoundaryLevelsCalibrator : ICalibrator
	{
		public void Calibrate(IList<FrameData> nonColebratedData)
		{
			int max = nonColebratedData.Max(x => x.Data);
			int min = nonColebratedData.Min(x => x.Data);
			double calibrationCharacteristic;
			foreach (FrameData fData in nonColebratedData)
			{
				calibrationCharacteristic = ((double)fData.Data - min) / ((double)max - min) * 100.0;
				fData.Data = (int)(calibrationCharacteristic * (max - min) + min) / 100;
			}
		}
	}
}
