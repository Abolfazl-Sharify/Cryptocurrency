using MediatR;

namespace Cryptocurrency.AppService.ExchangeRates.Queries.Get;

public class GetExchangeRatesQuery : IRequest<GetExchangeRatesQueryResult>
{
    public GetExchangeRatesQuery(decimal priceInUsd)
    {
        PriceInUsd = priceInUsd;
    }

    public decimal PriceInUsd { get; set; }

    public void Validate()
    {
        if (PriceInUsd <= 0)
        {
            throw new Exception("Could not fetch the price for the specified cryptocurrency or price is zero.");
        }
    }
}