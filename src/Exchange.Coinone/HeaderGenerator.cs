using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Exchange.Coinone
{
	class HeaderGenerator
	{
		private JsonClient Client;

		public HeaderGenerator(JsonClient client)
		{
			Client = client;
		}

		public void Register()
		{
			Client.AddHeaderGenerator("X-COINONE-PAYLOAD", On_X_Coinone_Payload);
			Client.AddHeaderGenerator("X-COINONE-SIGNATURE", On_X_Coinone_Signature);
		}

		private string On_X_Coinone_Payload(string uri, string payload)
		{
            if (string.IsNullOrEmpty(payload))
                return "";

			return Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));
		}
		private string On_X_Coinone_Signature(string uri, string payload)
		{
            if (Client.AuthData.IsAuthorized == false) return "";

            var payloadBase64 = "";
            if (string.IsNullOrEmpty(payload) == false)
			    payloadBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));
			var key = ((Auth)Client.AuthData).SecretKey;

			using (HMACSHA512 hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
			{
				var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payloadBase64));

				string hex = "";
				foreach (byte x in hash)
					hex += String.Format("{0:x2}", x);

				return hex;
			}
		}
	}
}
