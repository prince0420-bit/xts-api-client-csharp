using XTSClient.Core;

namespace XTSClient.MarketData
{
    public class FnoService : ApiClient
    {
        public FnoService(string token, string baseUrl)
            : base(token, baseUrl)
        {
        }

        public async Task GetNearMonthData(string symbol)
        {
            var url = $"{_baseUrl}/fno?symbol={symbol}&expiry=NEAR&interval=1min";

            var response = await _client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"F&O {symbol}: {data}");
        }
    }
}
