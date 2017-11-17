using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Korbit.Model
{
	// https://apidocs.korbit.co.kr/#ticker
	public class TickerResponse
	{
		public long timestamp;
		public int last;
	}

	// https://apidocs.korbit.co.kr/#detailed-ticker
	public class DetailedTickerResponse : TickerResponse
	{
		public int bid;
		public int ask;
		public int low;
		public int high;
		public double volume;
	}
}