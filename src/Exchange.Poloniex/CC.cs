using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Poloniex
{
	internal class CC
	{
		private static Dictionary<string, string> pair;

		static CC()
		{
			pair = new Dictionary<string, string>()
			{
				[CurrencyCode.BTC] = "USDT_BTC",
				[CurrencyCode.ETH] = "USDT_ETH",
				[CurrencyCode.ETC] = "USDT_ETC",
				[CurrencyCode.XRP] = "USDT_XRP",
				[CurrencyCode.BCH] = "USDT_BCH",
			};
		}

		public static string ToPoloniexCurrency(string cc)
		{
			return pair[cc];
		}
	}
}
