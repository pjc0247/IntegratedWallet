using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Exchange.Coinone.Model
{
	public class BalanceData
	{
		public double avail;
		public double balance;
	}

	public class GetBalancesResponse
	{
		public string errorCode;

		public Dictionary<string, BalanceData> balances;
	}

	public class GetBalancesResponseConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(GetBalancesResponse) == objectType;
		}

		public override object ReadJson(
			JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var obj = JObject.Load(reader);
			var result = new GetBalancesResponse();
			result.balances = new Dictionary<string, BalanceData>();

			foreach (var o in obj)
			{
				if (o.Key == "result") continue;
				if (o.Key == "normalWallets") continue;
				if (o.Key == "timestamp") continue;
				if (o.Key == "errorCode")
				{
					result.errorCode = o.Value.ToString();
					continue;
				}

				result.balances.Add(o.Key, o.Value.ToObject<BalanceData>());
			}

			return result;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
