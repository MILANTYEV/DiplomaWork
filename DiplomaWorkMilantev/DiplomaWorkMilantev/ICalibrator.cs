using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	public interface ICalibrator
	{
		void Calibrate(IList<FrameData> nonColebratedData);
	}
}
