IntegratedWallet
====

Goal
----
* 통합된 API
* 가격 감시
* 통합된 지갑 관리
* 통합된 잔고 로깅

Watcher
----
__Basic Ticker__<br>
Prints last price in every seconds.
```csharp
var pt = new PriceTicker(TimeSpan.FromSeconds(1));
    pt.AddTicker("coinone", coinone.ticker, (id, data) => {
        Console.WriteLine($"[COINONE] BTC : {data[CurrencyCode.BTC]}");
    });
```

__Conditional Alarm__<br>
Below code detects the price gap among exchange markets.
```csharp
new ConditionalAlarm(pt)
    .AddCondition((a, b) => {
        return a.Price >= b.Price * 1.05f
    },
    (a, b) => {
        Console.WriteLine($"{a.Currency} / {b.Currency}v");
    });
```