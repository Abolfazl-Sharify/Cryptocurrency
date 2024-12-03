using Cryptocurrency.AppService.Interfaces;
using MediatR;

namespace Cryptocurrency.AppService.ExchangeRates.Queries.Get;

public class GetExchangeRatesQueryHandler(ICryptoService cryptoService)
    : IRequestHandler<GetExchangeRatesQuery, GetExchangeRatesQueryResult>
{
    private readonly List<string> _currencies = ["USD", "EUR", "BRL", "GBP", "AUD"];
    private const string BaseCurrency = "EUR";

    public async Task<GetExchangeRatesQueryResult> Handle(GetExchangeRatesQuery request,
        CancellationToken cancellationToken)
    {
        request.Validate();

        var exchangeRates =
            await cryptoService.GetExchangeRateAsync(BaseCurrency, _currencies, cancellationToken);

        foreach (var exchangeRate in exchangeRates)
        {
            exchangeRates[exchangeRate.Key] = request.PriceInUsd * exchangeRate.Value;
        }

        // Prepare the result to return
        var result = new GetExchangeRatesQueryResult
        {
            PriceInUsd = request.PriceInUsd,
            PricesInOtherCurrencies = exchangeRates
        };

        return result;
    }
}