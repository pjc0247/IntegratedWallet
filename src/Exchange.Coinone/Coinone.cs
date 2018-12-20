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
		public static readonly string Endpoint = "https://api.coinone.co.kr";

		public Auth Auth;

		private JsonClient Api;

		public static Coinone Create()
		{
			return new Coinone(Endpoint);
		}

		public Coinone(string endpoint)
		{
			Api = new JsonClient(endpoint);
			AddConverters();

			Ticker = new Ticker(Api);
			Auth = new Auth();
			Wallet = new Wallet(Api);

			Api.AuthData = Auth;
			var hg = new HeaderGenerator(Api);
			hg.Register();
		}

		private void AddConverters()
		{
			Api.Converters.Add(new TickerAllResponseConverter());
			Api.Converters.Add(new GetBalancesResponseConverter());
		}
	}
}
