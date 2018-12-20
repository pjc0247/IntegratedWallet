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
	public delegate string GenerateHeaderDelegate(string uri, string payload);

	public class RestClient
	{
		public AuthBase AuthData;

		private Dictionary<string, GenerateHeaderDelegate> HeaderGenerators;

		public RestClient()
		{
			HeaderGenerators = new Dictionary<string, GenerateHeaderDelegate>();
		}

		public void AddHeaderGenerator(string key, GenerateHeaderDelegate callback)
		{
			HeaderGenerators.Add(key, callback);
		}

		public async Task<string> GetAsync(string uri)
		{
			var http = new HttpClient();

			if (AuthData != null && AuthData.IsAuthorized)
				http.DefaultRequestHeaders.Add("Authorization", "Bearer " + await AuthData.GetAccessTokenAsync());

			//Logger.WriteLine($"##GET : {uri}");

			foreach (var generator in HeaderGenerators)
			{
				var key = generator.Key;
				var value = generator.Value.Invoke(uri, null);

				http.DefaultRequestHeaders.Add(key, value);
			}

			//Logger.WriteLine("");

			var response = await http.GetAsync(uri);
			if (response.IsSuccessStatusCode == false)
			{
				Console.WriteLine(response.Content.ReadAsStringAsync().Result);
				throw new HttpRequestException($"{response.StatusCode}");
			}

			var responseBody = await response.Content.ReadAsStringAsync();
			//Logger.WriteLine(responseBody);

			return responseBody;
		}
		public async Task<string> PostAsync(string uri, string payload)
		{
			var http = new HttpClient();

			if (AuthData != null && AuthData.IsAuthorized)
				http.DefaultRequestHeaders.Add("Authorization", "Bearer " + await AuthData.GetAccessTokenAsync());

			Logger.WriteLine($"##POST : {uri}");
			Logger.WriteLine(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(payload), Formatting.Indented));

			foreach (var generator in HeaderGenerators)
			{
				var key = generator.Key;
				var value = generator.Value.Invoke(uri, payload);

				Logger.WriteLine($"[HG] {key} : {value}");

				http.DefaultRequestHeaders.Add(key, value);
			}

			Logger.WriteLine("");

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