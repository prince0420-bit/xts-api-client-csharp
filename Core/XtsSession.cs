using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace XTSClient.Core
{
    public class XtsSession
    {
        public string? Token { get; private set; }

        public async Task LoginAsync(string baseUrl, string appKey, string secretKey)
        {
            using var client = new HttpClient();

            var body = new
            {
                appKey = appKey,
                secretKey = secretKey
            };

            var response = await client.PostAsJsonAsync(
                $"{baseUrl}/marketdata/auth/login", body);

            var json = await response.Content.ReadAsStringAsync();

            Console.WriteLine("========== LOGIN RESPONSE RAW ==========");
            Console.WriteLine(json);
            Console.WriteLine("=======================================");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(" Login failed due to application access restriction (CTCL only)");

                return;
            }

            try
            {
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (root.TryGetProperty("result", out var result) &&
                    result.TryGetProperty("token", out var tokenElement))
                {
                    Token = tokenElement.GetString();
                }

                if (!string.IsNullOrEmpty(Token))
                {
                    Console.WriteLine("Login successful, token extracted");
                }
                else
                {
                    Console.WriteLine("Login response received but token not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error parsing login response");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
