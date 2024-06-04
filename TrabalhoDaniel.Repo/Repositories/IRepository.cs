namespace TrabalhoDaniel.Repo.Repositories;

public interface IRepository<T>
{   
    /*HttpClient*/
    Task<string> GetAllDataAsync();
    Task<string> GetOneDataAsync(int id);

    /*RestSharp*/
    Task<string> GetAllExternalDataWithRestSharpAsync();
    Task<string> GetOneExternalDataWithRestSharpAsync(int id);
    Task<string> GetAllExternalDataWithFlurHttpAsync();
    Task<string> GetOneExternalDataWithFlurHttpAsync(int id);
}
