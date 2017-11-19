using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Exchange.Util
{
	public static class ToStringExt
	{
		public static string ToJsonString(this object obj, bool pretty = false)
		{
			return JsonConvert.SerializeObject(obj, pretty ? Formatting.Indented : Formatting.None);
		}
	}
}
