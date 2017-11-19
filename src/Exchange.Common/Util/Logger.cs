using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
	public class Logger
	{
		[Conditional("DEBUG")]
		[Conditional("ENABLE_LOGGING")]
		public static void WriteLine(string msg)
		{
			Console.WriteLine(msg);
		}
	}
}
