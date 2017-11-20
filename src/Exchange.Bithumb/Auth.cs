using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Bithumb
{
	public class Auth : AuthBase
	{
		private string ClientId;
		private string ClientSecret;

		private JsonClient Api;

		public Auth(JsonClient client)
		{
			Api = client;
		}

		public void Login()
		{

		}
	}
}
