using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Korbit
{
	public class Korbit : MarketProviderBase
	{
		public static readonly string Endpoint = "https://api.korbit.co.kr/";
		public static readonly string EndpointTestNet = "https://api.korbit.co.kr/";

		public Auth Auth;

		private JsonClient Api;

		public static Korbit Create()
		{
			return new Korbit(Endpoint);
		}
		public static Korbit CreateTestNet()
		{
			return new Korbit(EndpointTestNet);
		}

		public Korbit(string endpoint)
		{
			Api = new JsonClient(endpoint);

			Ticker = new Ticker(Api);
			Auth = new Auth(Api);
		}
	}
}
