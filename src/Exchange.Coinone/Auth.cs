using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Coinone
{
	public class Auth : AuthBase
	{
		public string SecretKey;

		public void Login(string accessToken, string secretKey)
		{
			AccessToken = accessToken;
			SecretKey = secretKey;

			RefreshedAt = DateTime.Now;
			TokenLifetime = TimeSpan.FromDays(3650);
		}
	}
}
