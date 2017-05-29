using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	public class FramesSelector
	{
		private int _mask;
		private int _putMaskResult;
		private IIsFrameStrategy _strategy;

		public FramesSelector(int mask, int putMaskResult)
		{
			_mask = mask;
			_putMaskResult = putMaskResult;
			_strategy = new MaskIsFrameStrategy(mask, putMaskResult);
		}

		internal IIsFrameStrategy Strategy { get => _strategy; set => _strategy = value; }

		public static List<HexWord> getHexWords(byte[] data)
		{
			List<HexWord> words = new List<HexWord>();
			for (int i = 0; i < data.Length - 1; i += 2)
				words.Add(new HexWord(new byte[] { data[i], data[i + 1] }));
			return words;
		}

		public List<Frame> SelectFrames(TelemetricFileReader reader, int blocksCount)
		{
			byte[] buffer;
			Frame cadr = new Frame(0, 0);
			List<Frame> frames = new List<Frame>();
			for (int i = 0; i < blocksCount; i++)
			{
				InfoBlockStruct infoStruct = reader.ReadInfoStruct();

				buffer = reader.ReadBytes(infoStruct.InfoLength);
				List<HexWord> words = new List<HexWord>(getHexWords(buffer));
				if (words.Count != 512)
					Console.Write("");
				foreach (var word in words)
				{
					if (_strategy.IsFrame(word))
					{
						if (!cadr.HasBegin)
						{
							cadr.AddAllWordsStartingWith(words, word);
						}
						else
						{
							cadr.AddAllWordsBefore(words, word);
							if (cadr.Count == 519)
								frames.Add(cadr);
							cadr = new Frame(infoStruct.Sec, infoStruct.MSec);
						}
					}
				}
			}
			return frames;
		}
	}
}
