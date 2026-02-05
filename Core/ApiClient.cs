using System.Net.Http;

namespace XTSClient.Core
{
    public class ApiClient
    {
        protected readonly HttpClient _client;
        protected readonly string _baseUrl;

    
        public ApiClient(string token, string baseUrl)
        {
            _baseUrl = baseUrl;
            _client = new HttpClient();

            if (!string.IsNullOrEmpty(token))
            {
                _client.DefaultRequestHeaders.Add("Authorization", token);
            }
        }
    }
}
