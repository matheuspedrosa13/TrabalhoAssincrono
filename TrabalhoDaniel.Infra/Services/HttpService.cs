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

        // HttpClient methods

        public async Task<string> GetAllExternalDataAsync()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetOneExternalDataAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/todos/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // RestSharp methods
        public async Task<string> GetAllExternalDataWithRestSharpAsync()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/todos", Method.Get);
            var response = await client.ExecuteAsync(request);
            return response.Content!;
        }

        public async Task<string> GetOneExternalDataWithRestSharpAsync(int id)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest($"todos/{id}", Method.Get);
            var response = await client.ExecuteAsync(request);
            return response.Content!;
        }

        // Flurl.Http methods
        public async Task<string> GetAllExternalDataWithFlurlAsync()
        {
            var response = await "https://jsonplaceholder.typicode.com/todos".GetStringAsync();
            return response;
        }

        public async Task<string> GetOneExternalDataWithFlurlAsync(int id)
        {
            var response = await $"https://jsonplaceholder.typicode.com/todos/{id}".GetStringAsync();
            return response;
        }
    }
}
