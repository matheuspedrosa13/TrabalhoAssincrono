using TrabalhoDaniel.Repo.Entities;

namespace TrabalhoDaniel.Service.Services;

public interface IService
{
    Task<User> PostUser();
    Task<User> GetUser(string email);
    Task<bool?> LoginUser(string email, string password);
    Task<bool?> LogoutUser(string email);
    Task<User> CreateRelationship(string emailMainUser, string emailAddedUser);
    Task<User> RemoveRelationShip(string emailMainUser, string emailRemoveUser);
    Task<List<string>> RecommedationUser(string emailMainUser);
    Task<List<User>> GetAllUser();
}
