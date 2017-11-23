using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
	public class TickerBase
	{
		public virtual Task<double> QuerySingle(string currency)
		{
			throw new NotImplementedException();
		}
		public virtual Task<Dictionary<string, double>> QueryAll()
		{
			throw new NotImplementedException();
		}
	}
}
