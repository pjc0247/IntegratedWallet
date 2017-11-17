using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Bithumb
{
	using Model;

	public class Bithumb : MarketProviderBase
	{
		public static readonly string Endpoint = "https://api.bithumb.com/";

		public Auth Auth;

		private JsonClient Api;

		public static Bithumb Create()
		{
			return new Bithumb(Endpoint);
		}

		public Bithumb(string endpoint)
		{
			Api = new JsonClient(endpoint);
			AddConverters();

			Ticker = new Ticker(Api);
			Auth = new Auth(Api);
		}

		private void AddConverters()
		{
			Api.Converters.Add(new TickerDataConverter());
		}
	}
}
