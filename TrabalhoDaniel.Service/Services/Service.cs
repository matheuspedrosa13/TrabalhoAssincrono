using System.Reflection.Metadata;
using TrabalhoDaniel.Infra.Services;
using TrabalhoDaniel.Repo.Entities;
using TrabalhoDaniel.Repo.Repositories;

namespace TrabalhoDaniel.Service.Services;

public class Service : IService
{
    private readonly IRepository<string> _repository;

    public Service(IRepository<string> repository)
    {
        _repository = repository;
    }


    public async Task<User> PostUser()
    {
        string url = "https://api.invertexto.com/v1/faker?token=8137%7CBmRErcROxFRfvhTZWYIvEYL4Er5bfVKt"; // Coloque a URL correta aqui
        User user = await _repository.PostUserAsync(url);
        await _repository.SaveUserToMongoDB(user);
        return user;
    }

    public async Task<User> GetUser(string email)
    {
        User user = await _repository.GetUserByEmail(email);
        return user;
    }

    public async Task<string> LoginUser(string email, string password)
    {
        string user = await _repository.LoginUser(email, password);
        return user;
    }

    public async Task<string> LogoutUser(string email)
    {
        string user = await _repository.LogoutUser(email);
        return user;
    }

    public async Task<User> CreateRelationship(string emailMainUser, string emailAddedUser)
    {
        User userMain = await _repository.CreateRelationship(emailMainUser, emailAddedUser);
        return userMain;
    }

    public async Task<User> RemoveRelationShip(string emailMainUser, string emailRemoveUser)
    {
        User userMain = await _repository.RemoveRelationship(emailMainUser, emailRemoveUser);
        return userMain;
    }

    public async Task<List<string>> RecommedationUser(string emailMainUser)
    {
        List<string> listaUser = await _repository.RecommendUsers(emailMainUser);
        return listaUser;
    }

    public async Task<List<User>> GetAllUser()
    {
        List<User> listaUser = await _repository.GetAllUser();
        return listaUser;
    }

    public async Task<List<string>> GetUserRelations(string email)
    {
        List<string> listaUser = await _repository.GetUserRelations(email);
        return listaUser;
    }

    public async Task<bool?> GetLoginUser(string email)
    {
        bool? userLogin = await _repository.GetLoginUser(email);
        return userLogin;
    }
}
