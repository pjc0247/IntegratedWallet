using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Coinone
{
	using Model;

	public class Coinone : MarketProviderBase
	{
		public static readonly string Endpoint = "https://api.coinone.co.kr/";

		private JsonClient Api;

		public static Coinone Create()
		{
			return new Coinone(Endpoint);
		}

		public Coinone(string endpoint)
		{
			Api = new JsonClient(endpoint);
			AddConverters();

			ticker = new Ticker(Api);
		}
		private void AddConverters()
		{
			Api.Converters.Add(new TickerAllResponseConverter());
		}
	}
}
