using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Korbit
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
				{"currency_pair", CC.ToKorbitCurrency(currency)}
			};

			var response = await api.GetAsync<TickerResponse>("/v1/ticker", param);

			return response.last;
		}
		public async override Task<Dictionary<string, double>> QueryAll()
		{
			// https://stackoverflow.com/questions/23175611/task-whenall-result-ordering
			var results = await Task.WhenAll<double>(
				QuerySingle(CurrencyCode.BTC),
				QuerySingle(CurrencyCode.ETH),
				QuerySingle(CurrencyCode.ETC),
				QuerySingle(CurrencyCode.XRP),
				QuerySingle(CurrencyCode.BCH));

			return new Dictionary<string, double>()
			{
				[CurrencyCode.BTC] = results[0],
				[CurrencyCode.ETH] = results[1],
				[CurrencyCode.ETC] = results[2],
				[CurrencyCode.XRP] = results[3],
				[CurrencyCode.BCH] = results[4]
			};
		}
	}
}
