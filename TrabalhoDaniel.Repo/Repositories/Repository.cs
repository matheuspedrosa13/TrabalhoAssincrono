using TrabalhoDaniel.Infra.Services;

namespace TrabalhoDaniel.Repo.Repositories;

public class Repository : IRepository<string>
{

    private readonly HttpService _httpService;
    public Repository(HttpService client)
    {
        _httpService = client;
    }

    /*HttpClient*/
    public async Task<string> GetAllDataAsync()
    {
        return await _httpService.GetAllExternalDataAsync();
    }

    public async Task<string> GetOneDataAsync(int id)
    {
        return await _httpService.GetOneExternalDataAsync(id);
    }
    
    /*RestSharp*/
    public async Task<string> GetAllExternalDataWithRestSharpAsync()
    {
        return await _httpService.GetAllExternalDataWithRestSharpAsync();
    }

    public async Task<string> GetOneExternalDataWithRestSharpAsync(int id)
    {
        return await _httpService.GetOneExternalDataWithRestSharpAsync(id);
    }

    /*FlurHttp*/

    public async Task<string> GetAllExternalDataWithFlurHttpAsync()
    {
        return await _httpService.GetAllExternalDataWithFlurlAsync();
    }

    public async Task<string> GetOneExternalDataWithFlurHttpAsync(int id)
    {
        return await _httpService.GetOneExternalDataAsync(id);
    }
}
