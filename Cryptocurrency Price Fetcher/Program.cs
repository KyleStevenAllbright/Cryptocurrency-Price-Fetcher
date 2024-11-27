var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<BitcoinPriceService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Bitcoin Price Endpoint
app.MapGet("/bitcoinprice", async (BitcoinPriceService bitcoinPriceService) =>
{
    Console.WriteLine("Endpoint /bitcoinprice was hit.");
    try
    {
        var price = await bitcoinPriceService.GetBitcoinPriceAsync();
        return Results.Ok(new { BitcoinPriceUSD = price });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        return Results.Problem($"Error fetching Bitcoin price: {ex.Message}");
    }
})
.WithName("GetBitcoinPrice");

app.Run();
