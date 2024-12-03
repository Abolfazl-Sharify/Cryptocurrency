using Cryptocurrency.AppService.CryptoQuotes.Queries.Get;
using Cryptocurrency.AppService.Interfaces;
using Cryptocurrency.Infrastructure.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register MediatR for CQRS (Command/Query Handling)
builder.Services.AddMediatR(
    options => { options.RegisterServicesFromAssemblyContaining(typeof(GetCryptoQuotesQuery)); });

// Registers HttpClient as a service
builder.Services.AddHttpClient();

// Register CryptoServiceHttpClient with its dependencies
builder.Services.AddTransient<ICryptoService>(provider =>
{
    var httpClient = provider.GetRequiredService<HttpClient>();
    var coinMarketCapApiKey = builder.Configuration["CoinMarketCapApiKey"];
    var exchangeRateApiKey = builder.Configuration["ExchangeRateApiKey"];

    // Ensure the API keys are not null
    if (string.IsNullOrEmpty(coinMarketCapApiKey) || string.IsNullOrEmpty(exchangeRateApiKey))
    {
        throw new Exception("API keys are missing from the configuration.");
    }

    return new CryptoServiceHttpClient(httpClient, coinMarketCapApiKey, exchangeRateApiKey);
});

// Register Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Crypto_Quote_API",
        Version = "v1"
    });
});

var app = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint
var executionMode = app.Configuration.GetValue<string>("ExecutionMode");
if (executionMode?.ToLower() == "development")
{
    app.UseSwagger();
    
    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crypto_Quote_API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI as the default page (optional)
    });
}



// Configure HTTP request pipeline
app.UseHttpsRedirection();

// Map controller routes
app.MapControllers();

app.Run();