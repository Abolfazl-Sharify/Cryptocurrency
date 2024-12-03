using Cryptocurrency.Infrastructure.Services;
using Moq;
using Xunit;

namespace Cryptocurrency.Tests;

public class CryptocurrencyTests
{
    private readonly Mock<HttpClient> _httpClientMock;
    private readonly CryptoServiceHttpClient _cryptoService;

    public CryptocurrencyTests()
    {
        _httpClientMock = new Mock<HttpClient>();
        _cryptoService = new CryptoServiceHttpClient(_httpClientMock.Object, "b95be1e0-c8d3-40de-8e64-dfa3f3937ef4",
            "729dc7b5e1b99bb28dd98a51402d6b69");
    }
    
    [Fact]
    public async Task GetCryptoPriceAsync_ShouldReturnPrice()
    {
        // Arrange
        var cryptoCode = "BTC";
        var expectedPrice = 45000.25m;

        // Mocking the HttpClient call
        _httpClientMock.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>()))
            .ReturnsAsync(new HttpResponseMessage()
            {
                Content = new StringContent("{\"data\":{\"BTC\":{\"quote\":{\"USD\":{\"price\":45000.25}}}}}")
            });

        // Act
        var price = await _cryptoService.GetCryptoPriceAsync(cryptoCode);

        // Assert
        Assert.Equal(expectedPrice, price);
    }
    
    [Fact]
    public async Task GetExchangeRatesAsync_ShouldReturnExchangeRates()
    {
        // Arrange
        var baseCurrency = "USD";
        var targetCurrencies = new List<string> { "EUR", "BRL", "GBP", "AUD" };

        var expectedRates = new Dictionary<string, decimal>
        {
            { "EUR", 0.85m },
            { "BRL", 5.3m },
            { "GBP", 0.75m },
            { "AUD", 1.35m }
        };

        // Mocking the HttpClient call
        _httpClientMock.Setup(x => x.GetStringAsync(It.IsAny<string>()))
            .ReturnsAsync("{\"rates\":{\"EUR\":0.85,\"BRL\":5.3,\"GBP\":0.75,\"AUD\":1.35}}");

        // Act
        var exchangeRates = await _cryptoService.GetExchangeRateAsync(baseCurrency, targetCurrencies);

        // Assert
        Assert.Equal(expectedRates, exchangeRates);
    }
}