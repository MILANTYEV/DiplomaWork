using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	public class FramesParser
	{
		public static IList<FrameData> GetFramesData(List<Frame> cadrsList, int wordNumber,
			int from, int to, bool isYoungerByte)
		{
			IList<FrameData> cadrsDataList = new List<FrameData>();
			foreach (var c in cadrsList)
			{
				HexWord word = c.GetWord(wordNumber);
				byte wordByte;
				if (isYoungerByte)
					wordByte = word.GetYoungerByte();
				else
					wordByte = word.GetOlderByte();
				byte data = getBitsInByte(wordByte, from, to);
				cadrsDataList.Add(new FrameData(data, c.Seconds, c.MiliSeconds));
			}
			return cadrsDataList;
		}

		public static byte getBitsInByte(byte word, int from, int to)
		{
			string binary = Convert.ToString(Convert.ToInt32(word), 2);
			string zeroes = new string('0', 8 - binary.Length);
			binary = zeroes + binary;
			binary = binary.Substring(binary.Length - to, binary.Length - from);
			byte data = Convert.ToByte(binary, 2);
			return data;
		}
	}
}
