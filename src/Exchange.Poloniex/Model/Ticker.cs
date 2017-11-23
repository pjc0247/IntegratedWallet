using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Poloniex.Model
{
	public class CurrencyTickerData
	{
		public string last;
		public string isFrozen;
	}
	public class TickerResponse
	{
		public Dictionary<string, CurrencyTickerData> data;
	}
}
