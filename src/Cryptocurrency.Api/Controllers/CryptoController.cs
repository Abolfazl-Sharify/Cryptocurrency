using Cryptocurrency.AppService.CryptoQuotes.Queries.Get;
using Cryptocurrency.AppService.ExchangeRates.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocurrency.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CryptoController(IMediator mediator) : ControllerBase
{
    [HttpGet("{cryptoCode}")]
    public async Task<IActionResult> GetCryptoQuote(string cryptoCode, CancellationToken cancellationToken = default)
    {
        var priceInUsd = await mediator.Send(new GetCryptoQuotesQuery(cryptoCode), cancellationToken);
        var exchangeRates = await mediator.Send(new GetExchangeRatesQuery(priceInUsd), cancellationToken);
        return Ok(exchangeRates);
    }
}