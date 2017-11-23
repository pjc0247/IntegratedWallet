using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Poloniex
{
	using Model;

	public class Ticker : TickerBase
	{
		private JsonClient api;

		public Ticker(JsonClient client)
		{
			api = client;
		}

		public async override Task<double> QuerySingle(string currency)
		{
			var response = await api.GetAsync<Dictionary<string, CurrencyTickerData>>("/public?command=returnTicker", null);

			return double.Parse(response[CC.ToPoloniexCurrency(currency)].last);
		}
		public async override Task<Dictionary<string, double>> QueryAll()
		{
			var response = await api.GetAsync<Dictionary<string, CurrencyTickerData>>("/public?command=returnTicker", null);

			return new Dictionary<string, double>()
			{
				[CurrencyCode.BTC] = double.Parse((response[CC.ToPoloniexCurrency(CurrencyCode.BTC)].last)),
				[CurrencyCode.ETH] = double.Parse((response[CC.ToPoloniexCurrency(CurrencyCode.ETH)].last)),
				[CurrencyCode.ETC] = double.Parse((response[CC.ToPoloniexCurrency(CurrencyCode.ETC)].last)),
				[CurrencyCode.XRP] = double.Parse((response[CC.ToPoloniexCurrency(CurrencyCode.XRP)].last)),
				[CurrencyCode.BCH] = double.Parse((response[CC.ToPoloniexCurrency(CurrencyCode.BCH)].last)),
				[CurrencyCode.QTUM] = double.Parse((response[CC.ToPoloniexCurrency(CurrencyCode.QTUM)].last)),
			};
		}
	}
}
