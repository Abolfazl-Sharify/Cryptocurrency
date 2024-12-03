using Cryptocurrency.AppService.Interfaces;
using MediatR;

namespace Cryptocurrency.AppService.CryptoQuotes.Queries.Get;

public class GetCryptoQuotesQueryHandler(ICryptoService cryptoService)
    : IRequestHandler<GetCryptoQuotesQuery, decimal>
{
    public async Task<decimal> Handle(GetCryptoQuotesQuery request,
        CancellationToken cancellationToken)
    {
        request.Validate();
        
        return await cryptoService.GetCryptoPriceAsync(request.CryptoCode, cancellationToken);
    }
}