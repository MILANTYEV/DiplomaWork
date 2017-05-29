using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWorkMilantev
{
	public class InvalidReadingOrderException : ApplicationException
	{
		private string _message;

		public override string Message => _message;

		public InvalidReadingOrderException(string message)
		{
			_message = message;
		}
	}
}
