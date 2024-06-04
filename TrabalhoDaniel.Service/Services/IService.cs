namespace TrabalhoDaniel.Service.Services;

public interface IService
{
    Task<string> GetAllExternalDataAsync();
    Task<string> GetOneExternalDataAsync(int id);
    Task<string> GetAllExternalDataWithRestSharpAsync();
    Task<string> GetOneExternalDataWithRestSharpAsync(int id);
    Task<string> GetAllExternalDataWithFlurSharpAsync();
    Task<string> GetOneExternalDataWithFlurSharpAsync(int id);
}
