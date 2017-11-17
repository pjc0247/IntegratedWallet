using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Exchange
{
	public class RestClient
	{
		public AuthBase AuthData;

		public async Task<string> GetAsync(string uri)
		{
			var http = new HttpClient();

			if (AuthData != null && AuthData.IsAuthorized)
				http.DefaultRequestHeaders.Add("Authorization", "Bearer " + await AuthData.GetAccessTokenAsync());

			var response = await http.GetAsync(uri);

			if (response.IsSuccessStatusCode == false)
			{
				Console.WriteLine(response.Content.ReadAsStringAsync().Result);
				throw new HttpRequestException($"{response.StatusCode}");

			}

			return await response.Content.ReadAsStringAsync();
		}
		public async Task<string> PostAsync(string uri, string payload)
		{
			var http = new HttpClient();

			if (AuthData != null && AuthData.IsAuthorized)
				http.DefaultRequestHeaders.Add("Authorization", "Bearer " + await AuthData.GetAccessTokenAsync());

			var content = new StringContent(payload);
			var response = await http.PostAsync(uri, content);

			if (response.IsSuccessStatusCode == false)
			{
				Console.WriteLine(uri);
				Console.WriteLine(response.Content.ReadAsStringAsync().Result);
				throw new HttpRequestException($"{response.StatusCode}");
			}

			return await response.Content.ReadAsStringAsync();
		}
	}
}