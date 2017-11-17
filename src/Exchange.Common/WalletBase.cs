using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
	public class WalletBase
	{
		public virtual Task<WalletData> GetBalances()
		{
			throw new NotImplementedException();
		}
	}
}
