using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Coinone
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
			var param = new Dictionary<string, object>()
			{
				{"currency", CC.ToCoinoneCurrency(currency)}
			};
			var response = await api.GetAsync<TickerResponse>("/ticker/", param);

			return response.last;
		}
		public async override Task<Dictionary<string, double>> QueryAll()
		{
			var param = new Dictionary<string, object>()
			{
				{"currency", "all"}
			};
			var response = await api.GetAsync<TickerAllResponse>("/ticker/", param);

			return new Dictionary<string, double>()
			{
				[CurrencyCode.BTC] = (response.data[CC.ToCoinoneCurrency(CurrencyCode.BTC)].last),
				[CurrencyCode.ETH] = (response.data[CC.ToCoinoneCurrency(CurrencyCode.ETH)].last),
				[CurrencyCode.ETC] = (response.data[CC.ToCoinoneCurrency(CurrencyCode.ETC)].last),
				[CurrencyCode.XRP] = (response.data[CC.ToCoinoneCurrency(CurrencyCode.XRP)].last),
				[CurrencyCode.BCH] = (response.data[CC.ToCoinoneCurrency(CurrencyCode.BCH)].last),
				[CurrencyCode.QTUM] = (response.data[CC.ToCoinoneCurrency(CurrencyCode.QTUM)].last),
			};
		}
	}
}
