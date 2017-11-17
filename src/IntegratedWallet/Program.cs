using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Exchange;
using Exchange.Korbit;
using Exchange.Bithumb;
using Exchange.Coinone;

using Sentinel;

namespace IntegratedWallet
{
	class Program
	{
		static void Main(string[] args)
		{
			var korbit = Korbit.Create();
			var coinone = Coinone.Create();

			var pt = new PriceTicker(TimeSpan.FromSeconds(1));
			pt.AddTicker("coinone", coinone.ticker, (id, data) =>
			{
				Console.WriteLine($"BTC : {data[CurrencyCode.BTC]}");
			});
			pt.AddTicker("korbit", korbit.ticker, (id, data) =>
			{
				Console.WriteLine($"BTC : {data[CurrencyCode.BTC]}");
			});
			pt.Start();

			new ConditionalAlarm(pt)
				.AddCondition((a, b) =>
				{
					return true;
				},
				(a, b) =>
				{
					Console.WriteLine($"{a.Currency} / {b.Currency}v");
				});

			Console.Read();
		}
	}
}
