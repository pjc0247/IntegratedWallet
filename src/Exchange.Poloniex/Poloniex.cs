using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Poloniex
{
    public class Poloniex : MarketProviderBase
    {
		public static readonly string Endpoint = "https://poloniex.com";

		private JsonClient Api;

		public static Poloniex Create()
		{
			return new Poloniex(Endpoint);
		}

		public Poloniex(string endpoint)
		{
			Api = new JsonClient(endpoint);

			Ticker = new Ticker(Api);
		}
	}
}
