using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class BitcoinPriceService
{
    private readonly HttpClient _httpClient;

    public BitcoinPriceService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> GetBitcoinPriceAsync()
    {
        var response = await _httpClient.GetStringAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
        var data = JObject.Parse(response);
        return data["bpi"]["USD"]["rate_float"].Value<decimal>();
    }
}