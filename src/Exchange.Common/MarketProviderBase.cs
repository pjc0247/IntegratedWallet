using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
	public class MarketProviderBase
	{
		public TickerBase ticker { get; protected set; }
		public AuthBase auth { get; protected set; }
	}
}
