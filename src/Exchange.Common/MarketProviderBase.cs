﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
	public class MarketProviderBase
	{
		public TickerBase Ticker { get; protected set; }
		public WalletBase Wallet { get; protected set; }
	}
}
