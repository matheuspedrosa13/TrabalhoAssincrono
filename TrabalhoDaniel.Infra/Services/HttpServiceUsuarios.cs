using RestSharp;
using Flurl.Http;

namespace TrabalhoDaniel.Infra.Services;

public class HttpServiceUsuarios
{
    private readonly HttpClient _httpClient;

    public HttpServiceUsuarios(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // HttpClient methods

    public async Task<string> GetAllExternalDataAsync()
    {
        var response = await _httpClient.GetAsync("https://reqres.in/api/users");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetOneExternalDataAsync(int id)
    {
        var response = await _httpClient.GetAsync($"https://reqres.in/api/users/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    // RestSharp methods
    public async Task<string> GetExternalDataWithRestSharpAsync()
    {
        var client = new RestClient("https://reqres.in");
        var request = new RestRequest("api/users/2", Method.Get);
        var response = await client.ExecuteAsync(request);
        return response.Content;
    }

    public async Task<string> GetAllExternalDataWithRestSharpAsync()
    {
        var client = new RestClient("https://reqres.in");
        var request = new RestRequest("api/users", Method.Get);
        var response = await client.ExecuteAsync(request);
        return response.Content;
    }

    public async Task<string> GetOneExternalDataWithRestSharpAsync(int id)
    {
        var client = new RestClient("https://reqres.in");
        var request = new RestRequest($"api/users/{id}", Method.Get);
        var response = await client.ExecuteAsync(request);
        return response.Content;
    }

    // Flurl.Http methods
    public async Task<string> GetAllExternalDataWithFlurlAsync()
    {
        var response = await "https://reqres.in/api/users".GetStringAsync();
        return response;
    }

    public async Task<string> GetOneExternalDataWithFlurlAsync(int id)
    {
        var response = await $"https://reqres.in/api/users/{id}".GetStringAsync();
        return response;
    }
}
