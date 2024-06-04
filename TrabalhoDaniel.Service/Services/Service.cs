using TrabalhoDaniel.Infra.Services;
using TrabalhoDaniel.Repo.Repositories;

namespace TrabalhoDaniel.Service.Services;

public class Service : IService
{
    private readonly IRepository<string> _repository;

    public Service(IRepository<string> repository)
    {
        _repository = repository;
    }

    /*HttpClient*/
    public Task<string> GetAllExternalDataAsync()
    {
        return _repository.GetAllDataAsync();
    }

    public Task<string> GetOneExternalDataAsync(int id)
    {
        return _repository.GetOneDataAsync(id); 
    }

    /*RestSharp*/
    public Task<string> GetAllExternalDataWithRestSharpAsync()
    {
        return _repository.GetAllExternalDataWithRestSharpAsync();
    }

    public Task<string> GetOneExternalDataWithRestSharpAsync(int id)
    {
        return _repository.GetOneExternalDataWithRestSharpAsync(id);
    }

    /*FlurHttp*/
    public Task<string> GetAllExternalDataWithFlurSharpAsync()
    {
        return _repository.GetAllExternalDataWithFlurHttpAsync();
    }

    public Task<string> GetOneExternalDataWithFlurSharpAsync(int id)
    {
        return _repository.GetOneExternalDataWithFlurHttpAsync(id);
    }
}
