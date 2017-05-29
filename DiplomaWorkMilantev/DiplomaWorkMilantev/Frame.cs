using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	public class Frame : IEnumerable<HexWord>
	{
		private List<HexWord> words;
		private int seconds;
		private int miliSeconds;

		public int Seconds { get => seconds; set => seconds = value; }
		public int MiliSeconds { get => miliSeconds; set => miliSeconds = value; }
		public int Count { get => words.Count; }
		public bool HasBegin { get; set; }

		public Frame(int seconds, int miliSeconds)
		{
			words = new List<HexWord>();
			Seconds = seconds;
			MiliSeconds = miliSeconds;
		}

		public Frame(List<HexWord> words)
		{
			this.words = new List<HexWord>(words);
		}

		public void AddAllWordsStartingWith(List<HexWord> range, HexWord word)
		{
			words.AddRange(range.GetRange(range.IndexOf(word) + 1, range.Count - range.IndexOf(word) - 1));
			HasBegin = true;
		}

		public void AddAllWordsBefore(List<HexWord> range, HexWord word)
		{
			words.AddRange(range.GetRange(0, range.IndexOf(word) + 1));
		}

		public Frame Clone()
		{
			return new Frame(words);
		}

		public void RemoveAllWords()
		{
			words.RemoveAll((x) => true);
		}

		public HexWord GetWord(int index)
		{
			return words[index];
		}

		public IEnumerator<HexWord> GetEnumerator()
		{
			return ((IEnumerable<HexWord>)words).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<HexWord>)words).GetEnumerator();
		}

		public override int GetHashCode()
		{
			return words.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Frame))
				return false;
			Frame objCadr = (Frame)obj;
			return objCadr.words.Equals(words) && objCadr.Seconds.Equals(Seconds)
				&& objCadr.MiliSeconds.Equals(MiliSeconds);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < words.Count; i++)
				sb.Append(words[i].ToString()).Append(" ");
			return sb.Append("\n-------------\n").ToString();
		}
	}
}
