using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Coinone
{
	internal class CC
	{
		private static Dictionary<string, string> pair;

		static CC()
		{
			pair = new Dictionary<string, string>()
			{
				[CurrencyCode.BTC] = "btc",
				[CurrencyCode.ETH] = "eth",
				[CurrencyCode.ETC] = "etc",
				[CurrencyCode.XRP] = "xrp",
				[CurrencyCode.BCH] = "bch",
				[CurrencyCode.QTUM] = "qtum",
			};
		}

		public static string ToCoinoneCurrency(string cc)
		{
			return pair[cc];
		}
	}
}
