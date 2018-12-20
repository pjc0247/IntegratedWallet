IntegratedWallet
====

Features
----
* One-API regardless exchange you want to use.
* Realtime price monitoring
* 통합된 지갑 관리
* 통합된 잔고 로깅

Auth
----
__Coinone__<br>
Coinone requires `ACCESS_TOKEN` and `SECRET_KEY`. You can acquire your access tokens [here](https://coinone.co.kr/developer/oauth/).
```csharp
var coinone = Coinone.Create();
coinone.Auth.Login("YOUR_ACCESS_TOKEN", "YOUR_SECRET_KEY");
```

Wallet
----
__IntegratedWallet__ provides consistent interface between exchanges.
```csharp
var balanceData = await coinone.Wallet.GetBalances();

var btcBalance = balanceData.Balances[CurrencyCode.BTC].Balance;
var btcAvaliable = balanceData.Balances[CurrencyCode.BTC].Avaliable;
```

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
Detects the price gap among exchange markets.
```csharp
new ConditionalAlarm(pt)
    .AddCondition((a, b) => {
        return a.Price >= b.Price * 1.05f
    },
    (a, b) => {
        Console.WriteLine($"{a.Currency} / {b.Currency}v");
    });
```
