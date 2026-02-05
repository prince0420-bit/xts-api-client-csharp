using XTSClient.Core;

namespace XTSClient.MarketData
{
    public class OhlcService : ApiClient
    {
        public OhlcService(string token, string baseUrl)
            : base(token, baseUrl)
        {
        }

        public async Task GetOhlcAsync(string symbol)
        {
            var url = $"{_baseUrl}/ohlc?symbol={symbol}&interval=1day";

            var response = await _client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"OHLC {symbol}: {data}");
        }
    }
}
