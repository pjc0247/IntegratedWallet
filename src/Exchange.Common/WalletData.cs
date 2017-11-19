using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
	using Util;

	public class BalanceData
	{
		public double Balance;
		public double Avaliable;

		public override string ToString()
		{
			return this.ToJsonString();
		}
	}
	public class WalletData
	{
		public float KrwValue;

		public Dictionary<string, BalanceData> Balances;
	}
}
