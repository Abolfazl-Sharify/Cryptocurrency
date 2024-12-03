namespace Cryptocurrency.AppService.Interfaces;

public interface ICryptoService
{
    Task<decimal> GetCryptoPriceAsync(string cryptoCode,
        CancellationToken cancellationToken = default);

    Task<Dictionary<string, decimal>> GetExchangeRateAsync(string baseCurrency, List<string> targetCurrencies,
        CancellationToken cancellationToken = default);
}