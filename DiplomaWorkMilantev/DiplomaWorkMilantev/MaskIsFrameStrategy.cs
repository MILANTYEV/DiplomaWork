using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	public class MaskIsFrameStrategy : IIsFrameStrategy
	{
		private int _mask;
		private int _rightResult;

		public MaskIsFrameStrategy(int mask, int rightResult)
		{
			_mask = mask;
			_rightResult = rightResult;
		}

		public int Mask { get => _mask; set => _mask = value; }
		public int RightResult { get => _rightResult; set => _rightResult = value; }

		public bool IsFrame(HexWord word)
		{
			return word.PutMask(Mask, RightResult);
		}
	}
}
