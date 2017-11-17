using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exchange
{
	public class AuthBase
	{
		protected long Nonce = -1;
		protected string AccessToken;
		public string RefreshToken;
		public DateTime RefreshedAt;

		public bool IsAuthorized = false;

		protected virtual TimeSpan TokenLifetime
			=> TimeSpan.FromHours(1);

		public virtual async Task<string> GetAccessTokenAsync()
		{
			if (DateTime.Now - RefreshedAt >= TokenLifetime)
				await RefreshAccessTokenAsync();

			return AccessToken;
		}
		public virtual long GetNonce()
		{
			return Interlocked.Increment(ref Nonce);
		}

		protected void UpdateAuthData(string _RefreshToken, string _AccessToken)
		{
			RefreshedAt = DateTime.Now;
			RefreshToken = _RefreshToken;
			AccessToken = _AccessToken;

			IsAuthorized = true;
		}
		protected virtual Task RefreshAccessTokenAsync()
		{
			throw new NotImplementedException();
		}
	}
}