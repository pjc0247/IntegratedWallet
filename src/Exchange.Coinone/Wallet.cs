using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Coinone
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
				["access_token"] = accessToken,
				["nonce"] = 1
			};
			var response = await Api.PostAsync<GetBalancesResponse>("v2/account/balance/", param);

			return new WalletData()
			{
				Balances = response.balances.Select(x => new
				{
					Currency = x.Key,
					BalanceData = new Exchange.BalanceData
					{
						Avaliable = x.Value.avail,
						Balance = x.Value.balance
					}
				}).ToDictionary(x => x.Currency, y => y.BalanceData)
			};
		}
	}
}
