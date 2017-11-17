using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.Korbit
{
	using Model;

	public class Auth : AuthBase
    {
		private string ClientId;
		private string ClientSecret;

		private JsonClient Api;

		public Auth(JsonClient client)
		{
			Api = client;
		}

		public async Task Login(string clientId, string clientSecret, string username, string password)
		{
			await RequestAccessTokenAsync(clientId, clientSecret, username, password);

			ClientId = clientId;
			ClientSecret = clientSecret;
		}

		public async Task Login(string clientId, string clientSecret, string refreshToken)
		{
			await RefreshAccessTokenAsync();

			ClientId = clientId;
			ClientSecret = clientSecret;
		}

		public async Task RequestAccessTokenAsync(
			string clientId, string clientSecret, string username, string password)
		{
			var param = new Dictionary<string, object>()
			{
				{"client_id", ClientId},
				{"client_secret", ClientSecret},
				{"username", username},
				{"password", password},
				{"grant_type", "password"}
			};

			var resp = await Api.PostAsync<RequestAccessTokenResponse>("v1/oauth2/access_token", param);

			UpdateAuthData(resp.refresh_token, resp.access_token);
		}
		protected async override Task RefreshAccessTokenAsync()
		{
			var param = new Dictionary<string, object>()
			{
				{"client_id", ClientId},
				{"client_secret", ClientSecret},
				{"refresh_token", RefreshToken},
				{"grant_type", "refresh_token"}
			};

			var resp = await Api.PostAsync<RequestAccessTokenResponse>("v1/oauth2/access_token", param);

			UpdateAuthData(resp.refresh_token, resp.access_token);
		}
	}
}
