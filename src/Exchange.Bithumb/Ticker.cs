using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Bithumb
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
			var cc = CC.ToBithumbCurrency(currency);
			var response = await api.GetAsync<TickerResponse>("/public/ticker/" + cc, null);

			return float.Parse(response.data.closing_price);
		}
		public async override Task<Dictionary<string, double>> QueryAll()
		{
			var response = await api.GetAsync<TickerAllResponse>("/public/ticker/ALL", null);

			return new Dictionary<string, double>()
			{
				[CurrencyCode.BTC] = float.Parse(response.data[CC.ToBithumbCurrency(CurrencyCode.BTC)].closing_price),
				[CurrencyCode.ETH] = float.Parse(response.data[CC.ToBithumbCurrency(CurrencyCode.ETH)].closing_price),
				[CurrencyCode.ETC] = float.Parse(response.data[CC.ToBithumbCurrency(CurrencyCode.ETC)].closing_price),
				[CurrencyCode.XRP] = float.Parse(response.data[CC.ToBithumbCurrency(CurrencyCode.XRP)].closing_price),
				[CurrencyCode.BCH] = float.Parse(response.data[CC.ToBithumbCurrency(CurrencyCode.BCH)].closing_price),
				[CurrencyCode.QTUM] = float.Parse(response.data[CC.ToBithumbCurrency(CurrencyCode.QTUM)].closing_price),
			};
		}
	}
}
