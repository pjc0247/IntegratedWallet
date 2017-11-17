using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentinel
{
	public delegate bool OnEvalCondition(PriceData a, PriceData b);
	public delegate void OnConditionHit(PriceData a, PriceData b);

	public class ConditionalAlarm
	{
		private PriceTicker PriceTicker;

		private Dictionary<string, Dictionary<string, float>> PriceTable;
		private Dictionary<OnEvalCondition, OnConditionHit> Conditionas;

		public ConditionalAlarm(PriceTicker pt)
		{
			PriceTable = new Dictionary<string, Dictionary<string, float>>();
			Conditionas = new Dictionary<OnEvalCondition, OnConditionHit>();

			PriceTicker = pt;
			PriceTicker.AddGlobalCallback(OnTicker);
		}

		public ConditionalAlarm AddCondition(OnEvalCondition eval, OnConditionHit hit)
		{
			Conditionas.Add(eval, hit);
			return this;
		}

		private void OnTicker(string id, Dictionary<string, float> prices)
		{
			PriceTable[id] = prices;

			foreach (var item in PriceTable)
			{
				var opponentId = item.Key;
				if (opponentId == id) continue;

				foreach (var currency in prices)
				{
					if (item.Value.ContainsKey(currency.Key) == false)
						continue;

					var opponent = item.Value[currency.Key];
					var a = new PriceData()
					{
						Currency = currency.Key,
						Price = currency.Value,
						Id = id
					};
					var b = new PriceData()
					{
						Currency = currency.Key,
						Price = opponent,
						Id = opponentId
					};

					foreach (var c in Conditionas)
					{
						if (c.Key(a, b))
							c.Value(a, b);
						else if (c.Key(b, a))
							c.Value(b, a);
					}
				}
			}
		}
	}
}
