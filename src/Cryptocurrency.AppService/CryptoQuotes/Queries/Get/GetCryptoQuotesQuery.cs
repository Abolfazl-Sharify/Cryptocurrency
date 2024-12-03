using MediatR;

namespace Cryptocurrency.AppService.CryptoQuotes.Queries.Get;

public class GetCryptoQuotesQuery : IRequest<decimal>
{
    public GetCryptoQuotesQuery(string cryptoCode)
    {
        CryptoCode = cryptoCode.Trim();
    }

    public string CryptoCode { get; set; }

    public void Validate()
    {
        ArgumentNullException.ThrowIfNull(CryptoCode);
        
        if (CryptoCode.Length != 3)
        {
            throw new Exception("CryptoCode will be 3 character");
        }
    }
}