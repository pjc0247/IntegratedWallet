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
