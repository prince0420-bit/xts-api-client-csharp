using System.Net.WebSockets;
using System.Text;

namespace XTSClient.Socket
{
    public class MarketSocket
    {
        public async Task StartAsync(string socketUrl)
        {
            using var socket = new ClientWebSocket();
            await socket.ConnectAsync(new Uri(socketUrl), CancellationToken.None);

            var msg = Encoding.UTF8.GetBytes("test stream");
            await socket.SendAsync(
                msg,
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);

            var buffer = new byte[1024];
            var result = await socket.ReceiveAsync(
                new ArraySegment<byte>(buffer),
                CancellationToken.None);

            Console.WriteLine(
                "Socket Response: " +
                Encoding.UTF8.GetString(buffer, 0, result.Count)
            );
        }
    }
}
