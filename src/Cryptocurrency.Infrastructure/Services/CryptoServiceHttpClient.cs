using Cryptocurrency.AppService.Interfaces;
using Newtonsoft.Json.Linq;

namespace Cryptocurrency.Infrastructure.Services;

public class CryptoServiceHttpClient : ICryptoService
{
    private readonly HttpClient _httpClient;
    private readonly string _coinMarketCapApiKey;
    private readonly string _exchangeRateApiKey;

    public CryptoServiceHttpClient(HttpClient httpClient, string coinMarketCapApiKey, string exchangeRateApiKey)
    {
        _httpClient = httpClient;
        _coinMarketCapApiKey = coinMarketCapApiKey;
        _exchangeRateApiKey = exchangeRateApiKey;
    }

    public async Task<decimal> GetCryptoPriceAsync(string cryptoCode,
        CancellationToken cancellationToken = default)
    {
        var coinMarketCapUrl =
            $"https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest?symbol={cryptoCode.ToUpper()}";
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, coinMarketCapUrl);
        requestMessage.Headers.Add("X-CMC_PRO_API_KEY", _coinMarketCapApiKey);

        var response = await _httpClient.SendAsync(requestMessage, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var data = JObject.Parse(content);

        // Get the price in USD (assuming USD is the main currency)
        var price = (data["data"]?[cryptoCode.ToUpper()]?["quote"]?["USD"]?["price"] ?? 0).Value<decimal>();

        return price;
    }

    public async Task<Dictionary<string, decimal>> GetExchangeRateAsync(string baseCurrency, List<string> targetCurrencies,
        CancellationToken cancellationToken = default)
    {
        var targetCurrenciesStr = string.Join(",", targetCurrencies);

        var exchangeRateUrl =
            $"https://api.exchangeratesapi.io/v1/latest?access_key={_exchangeRateApiKey}&base={baseCurrency}&symbols={targetCurrenciesStr}";

        var response = await _httpClient.GetStringAsync(exchangeRateUrl, cancellationToken);

        var data = JObject.Parse(response);
        var exchangeRates = new Dictionary<string, decimal>();

        foreach (var currency in targetCurrencies)
        {
            if (data["rates"]?[currency] != null)
            {
                exchangeRates[currency] = (data["rates"]?[currency] ?? 0).Value<decimal>();
            }
        }

        return exchangeRates;
    }
}