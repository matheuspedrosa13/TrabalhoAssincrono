using TrabalhoDaniel.Repo.Entities;

namespace TrabalhoDaniel.Repo.Repositories;

public interface IRepository<T>
{  
    Task<User> PostUserAsync(string url);
    Task SaveUserToMongoDB(User user);
    Task<User> GetUserByEmail(string email);
    Task<string> LoginUser(string email, string password);
    Task<string> LogoutUser(string email);
    Task<User> CreateRelationship(string emailMainUser, string emailUserAdded);
    Task<User> RemoveRelationship(string emailMainUser, string emailUserRemoved);
    Task<List<string>> RecommendUsers(string email);
    Task<List<string>> GetUserRelations(string email);
    Task<bool?> GetLoginUser(string email);
    Task<List<User>> GetAllUser();
}
