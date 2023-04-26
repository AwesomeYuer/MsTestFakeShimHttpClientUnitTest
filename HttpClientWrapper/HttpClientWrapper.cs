namespace Microshaoft
{
    public class HttpClientWrapper
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<HttpResponseMessage> SendAsync()
        {
            return await _httpClient.SendAsync(new HttpRequestMessage());
        }

    }
    public static class HttpClientHelper
    { 
        private static HttpClient? _httpClient;

    
    
    }
}