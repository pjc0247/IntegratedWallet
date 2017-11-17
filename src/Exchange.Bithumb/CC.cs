using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Bithumb
{
	internal class CC
	{
		private static Dictionary<string, string> pair;

		static CC()
		{
			pair = new Dictionary<string, string>()
			{
				[CurrencyCode.BTC] = "BTC",
				[CurrencyCode.ETH] = "ETH",
				[CurrencyCode.ETC] = "ETC",
				[CurrencyCode.XRP] = "XRP",
				[CurrencyCode.BCH] = "BCH",
				[CurrencyCode.QTUM] = "QTUM",
			};
		}

		public static string ToBithumbCurrency(string cc)
		{
			return pair[cc];
		}
	}
}
