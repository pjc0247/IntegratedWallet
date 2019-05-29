using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Upbit
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
            var response = await api.GetAsync<TickerResponse[]>($"/v1/ticker?markets=KRW-{currency.ToUpper()}", null);

            return response[0].trade_price;
        }
        public async override Task<Dictionary<string, double>> QueryAll()
        {
            var response = await api.GetAsync<TickerResponse[]>(
                $"/v1/ticker?markets=KRW-BTC,KRW-ETH,KRW-XRP,KRW-DASH,KRW-EOS", null);

            return response.ToDictionary(x => x.market.Split('-')[1], x => x.trade_price);
        }
    }
}
