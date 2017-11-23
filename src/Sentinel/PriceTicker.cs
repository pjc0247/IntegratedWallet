using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Exchange;

namespace Sentinel
{
	public delegate void OnTicker(string id, Dictionary<string, double> prices);

    public class PriceTicker
    {
		private class TickerAndCallback
		{
			public string Id;
			public TickerBase Ticker;
			public OnTicker Callback;
		}

		public TimeSpan Interval = TimeSpan.FromSeconds(1);

		private Dictionary<string, TickerAndCallback> Tickers;
		private Thread Worker;

		private bool IsRunning = false;

		public PriceTicker(TimeSpan interval)
		{
			Tickers = new Dictionary<string, TickerAndCallback>();

			Interval = interval;
		}

		public void AddTicker(string id, TickerBase ticker, OnTicker callback)
		{
			if (IsRunning)
				throw new InvalidOperationException("isRunning => true");

			Tickers.Add(id, new TickerAndCallback()
			{
				Id = id,
				Ticker = ticker,
				Callback = callback
			});
		}
		public void AddGlobalCallback(OnTicker callback)
		{
			if (IsRunning)
				throw new InvalidOperationException("isRunning => true");

			foreach (var data in Tickers)
				data.Value.Callback += callback;
		}

		public void Start()
		{
			Worker = new Thread(WorkerFunc);
			Worker.Start();
		}

		// todo - scheduling
		private void WorkerFunc()
		{
			while (true)
			{
				foreach(var ticker in Tickers)
				{
					ticker.Value.Ticker.QueryAll().ContinueWith(
						result =>
						{
							if (result.IsFaulted)
								;
							else
							{
								ticker.Value.Callback(ticker.Key, result.Result);
							}
						});
				}

				Thread.Sleep(Interval);
			}
		}
    }
}
