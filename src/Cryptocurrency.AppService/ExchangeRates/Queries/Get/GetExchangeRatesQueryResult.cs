namespace Cryptocurrency.AppService.ExchangeRates.Queries.Get;

public class GetExchangeRatesQueryResult
{
    public decimal PriceInUsd { get; set; }
    public Dictionary<string, decimal> PricesInOtherCurrencies { get; set; } = new();
}