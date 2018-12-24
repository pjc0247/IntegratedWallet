using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Upbit
{
    public class Upbit : MarketProviderBase
    {
        public static readonly string Endpoint = "https://api.upbit.com";

        //public Auth Auth;

        private JsonClient Api;

        public static Upbit Create()
        {
            return new Upbit(Endpoint);
        }

        public Upbit(string endpoint)
        {
            Api = new JsonClient(endpoint);

            Ticker = new Ticker(Api);
            //Auth = new Auth(Api);
        }
    }
}
