// TrabalhoDaniel.Infra.Services/HttpService.cs

using RestSharp;
using Flurl.Http;

namespace TrabalhoDaniel.Infra.Services
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> CreateUser()
        {
            var response = await _httpClient.GetAsync("https://api.invertexto.com/v1/faker?token=8137%7CBmRErcROxFRfvhTZWYIvEYL4Er5bfVKt");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
