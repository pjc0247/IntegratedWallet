using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Korbit
{
	internal class CC
	{
		private static Dictionary<string, string> pair;

		static CC()
		{
			pair = new Dictionary<string, string>()
			{
				[CurrencyCode.BTC] = "btc_krw",
				[CurrencyCode.ETH] = "eth_krw",
				[CurrencyCode.ETC] = "etc_krw",
				[CurrencyCode.XRP] = "xrp_krw",
				[CurrencyCode.BCH] = "bch_krw",
			};
		}

		public static string ToKorbitCurrency(string cc)
		{
			return pair[cc];
		}
	}
}
