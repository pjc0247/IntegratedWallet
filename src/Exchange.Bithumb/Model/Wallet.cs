using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Bithumb.Model
{
	public class BalanceData
	{
		public double total_krw;
		public double available_krw;

		public double total_btc;
		public double available_btc;

		public double total_bch;
		public double available_bch;

		public double total_xrp;
		public double available_xrp;

		public double total_qtum;
		public double available_qtum;

		public double total_eth;
		public double available_eth;

		public double total_etc;
		public double available_etc;
	}
	public class GetBalancesResponse
	{
		public string status;

		public BalanceData data;
	}
}
