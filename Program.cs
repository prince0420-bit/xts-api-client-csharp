using Microsoft.Extensions.Configuration;
using XTSClient.Core;
using XTSClient.MarketData;
using XTSClient.Socket;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("XTS Client starting...");

        // Load config
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var xts = config.GetSection("XTS");

        string baseUrl = xts["BaseUrl"];
        string socketUrl = xts["SocketUrl"];
        string appKey = xts["AppKey"];
        string secretKey = xts["SecretKey"];

        // Login
        var session = new XtsSession();
        await session.LoginAsync(baseUrl, appKey, secretKey);

        if (string.IsNullOrEmpty(session.Token))
        {
            Console.WriteLine("❌ Login failed");
            return;
        }

        Console.WriteLine("✅ Login successful");

        // OHLC
        var ohlc = new OhlcService(session.Token, baseUrl);
        await ohlc.GetOhlcAsync("RELIANCE");

        // F&O
        var fno = new FnoService(session.Token, baseUrl);
        await fno.GetNearMonthData("HDFCBANK");

        // Socket (mock)
        var socket = new MarketSocket();
        await socket.StartAsync(socketUrl);

        Console.WriteLine("✅ Program finished");
    }
}
