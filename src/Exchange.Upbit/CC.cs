using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Upbit
{
    internal class CC
    {
        private static Dictionary<string, string> pair;

        static CC()
        {
            pair = new Dictionary<string, string>()
            {
                [CurrencyCode.BTC] = "KRW-BTC",
                [CurrencyCode.ETH] = "KRW-ETH",
                [CurrencyCode.ETC] = "KRW-ETC",
                [CurrencyCode.XRP] = "KRW-XRP",
                [CurrencyCode.BCH] = "KRW-BCH",
            };
        }

        public static string ToUpbitCurrency(string cc)
        {
            return pair[cc];
        }
    }
}
