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
	public class TickerData
	{
		public int last;
	}
	public class TickerResponse : TickerData
	{
		public string errorCode;
	}
	public class TickerAllResponse
	{
		public string errorCode;

		public Dictionary<string, TickerData> data;
	}

	public class TickerAllResponseConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(TickerAllResponse) == objectType;
		}

		public override object ReadJson(
			JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var obj = JObject.Load(reader);
			var result = new TickerAllResponse();
			result.data = new Dictionary<string, TickerData>();

			foreach (var o in obj)
			{
				if (o.Key == "result") continue;
				if (o.Key == "timestamp") continue;
				if (o.Key == "errorCode")
				{
					result.errorCode = o.Value.ToString();
					continue;
				}

				result.data.Add(o.Key, o.Value.ToObject<TickerData>());
				//result.Add(o.Key, o.Value.ToObject<TickerData>());
			}

			return result;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
