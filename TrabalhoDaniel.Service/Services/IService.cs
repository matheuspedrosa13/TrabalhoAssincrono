using TrabalhoDaniel.Repo.Entities;

namespace TrabalhoDaniel.Service.Services;

public interface IService
{
    Task<User> PostUser();
    Task<User> GetUser(string email);
    Task<string> LoginUser(string email, string password);
    Task<string> LogoutUser(string email);
    Task<User> CreateRelationship(string emailMainUser, string emailAddedUser);
    Task<User> RemoveRelationShip(string emailMainUser, string emailRemoveUser);
    Task<List<string>> RecommedationUser(string emailMainUser);
    Task<List<string>> GetUserRelations(string email);
    Task<bool?> GetLoginUser(string email);
    Task<List<User>> GetAllUser();
}
