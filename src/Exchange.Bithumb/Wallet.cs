using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Bithumb
{
	using Model;

	public class Wallet : WalletBase
	{
		private JsonClient Api;

		public Wallet(JsonClient client)
		{
			Api = client;
		}

		public async override Task<WalletData> GetBalances()
		{
			var accessToken = await Api.AuthData.GetAccessTokenAsync();

			var param = new Dictionary<string, object>()
			{
				["apiKey"] = accessToken,
				["secretKey"] = "",
				["currency"] = "ALL"
			};
			var response = await Api.PostAsync<GetBalancesResponse>("info/balance", param);

			return new WalletData()
			{
				Balances = new Dictionary<string, Exchange.BalanceData>()
				{
					[CurrencyCode.KRW] = new Exchange.BalanceData()
					{
						Balance = response.data.total_krw,
						Avaliable = response.data.available_krw
					},
					[CurrencyCode.BTC] = new Exchange.BalanceData(){
						Balance = response.data.total_btc,
						Avaliable = response.data.available_btc
					},
					[CurrencyCode.BCH] = new Exchange.BalanceData()
					{
						Balance = response.data.total_bch,
						Avaliable = response.data.available_bch
					},
					[CurrencyCode.XRP] = new Exchange.BalanceData()
					{
						Balance = response.data.total_xrp,
						Avaliable = response.data.available_xrp
					},
					[CurrencyCode.ETH] = new Exchange.BalanceData()
					{
						Balance = response.data.total_eth,
						Avaliable = response.data.available_eth
					},
					[CurrencyCode.ETC] = new Exchange.BalanceData()
					{
						Balance = response.data.total_etc,
						Avaliable = response.data.available_etc
					}
				}
			};
		}
	}
}
