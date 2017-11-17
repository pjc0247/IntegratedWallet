using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Exchange.Bithumb.Model
{
	// https://www.bithumb.com/u1/US127
	public class TickerData
	{
		public string closing_price; 
	}
	public class TickerAllData : Dictionary<string, TickerData>
	{
		public long date;
	}

	public class TickerResponse
	{
		public string status;
		public TickerData data;
	}

	public class TickerAllResponse
	{
		public string status;
		public Dictionary<string, TickerData> data;
	}

	public class TickerDataConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(Dictionary<string, TickerData>) == objectType;
		}

		public override object ReadJson(
			JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var obj = JObject.Load(reader);
			var result = new Dictionary<string, TickerData>();

			foreach (var o in obj)
			{
				if (o.Key == "date") continue;

				result.Add(o.Key, o.Value.ToObject<TickerData>());
			}

			return result;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
