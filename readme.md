IntegratedWallet
====

Watcher
----
__Basic Ticker__
```csharp
var pt = new PriceTicker(TimeSpan.FromSeconds(1));
    pt.AddTicker("coinone", coinone.ticker, (id, data) => {
        Console.WriteLine($"[COINONE] BTC : {data[CurrencyCode.BTC]}");
    });
```

__Conditional Alarm__
```csharp
new ConditionalAlarm(pt)
    .AddCondition((a, b) => {
        return a.Price >= b.Price * 1.05f
    },
    (a, b) => {
        Console.WriteLine($"{a.Currency} / {b.Currency}v");
    });
```