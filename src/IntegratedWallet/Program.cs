using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Exchange;
using Exchange.Korbit;
using Exchange.Bithumb;
using Exchange.Coinone;
using Exchange.Upbit;

using Sentinel;

namespace IntegratedWallet
{
	class Program
	{
		static void Main(string[] args)
		{
			var korbit = Korbit.Create();
			var coinone = Coinone.Create();
            var bithumb = Bithumb.Create();
            var upbit = Upbit.Create();

			var pt = new PriceTicker(TimeSpan.FromSeconds(1));
			//pt.AddTicker("coinone", coinone.Ticker, (id, data) =>
		//	{
		//	});
			pt.AddTicker("korbit", korbit.Ticker, (id, data) =>
			{
                Console.WriteLine($"KB BTC : {data[CurrencyCode.BTC]}");
            });
            pt.AddTicker("bithumb", bithumb.Ticker, (id, data) =>
            {
                //Console.WriteLine($"BTH BTC : {data[CurrencyCode.BTC]}");
            });
            pt.AddTicker("upbit", upbit.Ticker, (id, data) =>
            {
                //Console.WriteLine($"upbit BTC : {data[CurrencyCode.BTC]}");
            });
            pt.Start();

			new ConditionalAlarm(pt)
				.AddCondition((a, b) =>
				{
                    return a.Price >= b.Price * 1.005f;
                },
				(a, b) =>
				{
                    var profit = a.Price / b.Price;
					Console.WriteLine(
                        $"{a.Id} {a.Currency} {a.Price} / {b.Id} {b.Currency} {b.Price} / {profit}");
				});

			Console.Read();
		}
	}
}
