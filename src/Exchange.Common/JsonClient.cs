using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Exchange
{
	public class JsonClient : RestClient
	{
		public List<JsonConverter> Converters = new List<JsonConverter>();

		private string Endpoint;

		public JsonClient(string endpoint)
		{
			Endpoint = endpoint;
		}

		private string ToQueryString(Dictionary<string, object> dic)
		{
			if (dic == null || dic.Count == 0)
				return "";

			var array = (from e in dic
						 select string.Format("{0}={1}", Uri.EscapeUriString(e.Key), Uri.EscapeUriString(e.Value?.ToString() ?? "")))
				.ToArray();
			return "?" + string.Join("&", array);
		}

		public async Task<T> GetAsync<T>(string uri, Dictionary<string, object> param)
		{
			var json = await GetAsync(Endpoint + uri + ToQueryString(param));

			return JsonConvert.DeserializeObject<T>(json, Converters.ToArray());
		}
		public async Task<T> PostAsync<T>(string uri, Dictionary<string, object> param)
		{
			var json = await PostAsync(
				Endpoint + uri + ToQueryString(param),
				JsonConvert.SerializeObject(param));

			return JsonConvert.DeserializeObject<T>(json, Converters.ToArray());
		}
	}
}
