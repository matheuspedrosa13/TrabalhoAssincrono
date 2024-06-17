using System.Text.Json;
using MongoDB.Driver;
using TrabalhoDaniel.Infra.Services;
using TrabalhoDaniel.Repo.Entities;

namespace TrabalhoDaniel.Repo.Repositories;

public class Repository : IRepository<string>
{
    private static readonly string connectionString = "mongodb+srv://matheuspmc13:Bx3JBEy5Tal3SPFV@redesocial.d8uoxsx.mongodb.net/?retryWrites=true&w=majority&appName=RedeSocial";
    private static readonly string databaseName = "UserRede";
    private static readonly string collectionName = "User";
    private readonly HttpService _httpService;

    public Repository(HttpService client)
    {
        _httpService = client;
    }

    public async Task SaveUserToMongoDB(User user)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        var collection = database.GetCollection<User>(collectionName);
        string[] parts = user.Name.Split(' ');
        string firstNameForPassword = parts[0].ToLower();
        user.Password = string.Concat(firstNameForPassword,1234);
        await collection.InsertOneAsync(user);
        Console.WriteLine("User inserted successfully!");
    }

    public async Task<User> PostUserAsync(string url)
    {
        using HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            User user = JsonSerializer.Deserialize<User>(jsonResponse)!;
            return user;
        }
        else
        {

            throw new Exception("Failed to retrieve data from server");
        }
    }

    public async Task<List<User>> GetAllUser()
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        var collection = database.GetCollection<User>(collectionName);

        var allUsers = await collection.Find(Builders<User>.Filter.Empty).ToListAsync();
        return allUsers;
    }

    public async Task<User> GetUserByEmail(string email){
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        var collection = database.GetCollection<User>(collectionName);

        var filter = Builders<User>.Filter
            .Eq(r => r.Email, email);

        return await collection.Find(filter).FirstAsync();
    }

    public async Task<bool?> LoginUser(string email, string password){
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        var collection = database.GetCollection<User>(collectionName);

        var filterEmail = Builders<User>.Filter.Eq(r => r.Email, email);
        var user = await collection.Find(filterEmail).FirstOrDefaultAsync();

        if (user == null)
        {
            throw new Exception("Usuário não encontrado.");
        }
        if (user.Logado == true)
        {
            throw new Exception("Usuário já logado.");
        }
        if (user.Password != password)
        {
            throw new Exception("Senha incorreta.");
        }
        var update = Builders<User>.Update
        .Set(user => user.Logado, true);

        await collection.UpdateOneAsync(filterEmail, update);
        return user.Logado;
    }

    public async Task<bool?> LogoutUser(string email){
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        var collection = database.GetCollection<User>(collectionName);

        var filterEmail = Builders<User>.Filter.Eq(r => r.Email, email);
        var user = await collection.Find(filterEmail).FirstOrDefaultAsync();

        if (user == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        if (user.Logado == false)
        {
            throw new Exception("Usuário já deslogado.");
        }

        var update = Builders<User>.Update
        .Set(user => user.Logado, false);

        await collection.UpdateOneAsync(filterEmail, update);
        return user.Logado;
    }

    public async Task<User> CreateRelationship(string emailMainUser, string emailUserAdded)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        var collection = database.GetCollection<User>(collectionName);

        var filterEmail = Builders<User>.Filter.Eq(r => r.Email, emailMainUser);
        var mainUser = await collection.Find(filterEmail).FirstOrDefaultAsync();
        var filterEmailUserAdded = Builders<User>.Filter.Eq(r => r.Email, emailUserAdded);
        var addedUser = await collection.Find(filterEmailUserAdded).FirstOrDefaultAsync();

        if (mainUser == null || addedUser == null)
        {
            throw new Exception("Usuário não encontrado.");
        }
        else
        {
            var updateMainUser = Builders<User>.Update.AddToSet(user => user.Relacoes, addedUser.Email);
            await collection.UpdateOneAsync(filterEmail, updateMainUser);
            return mainUser;
        }
    }


    public async Task<User> RemoveRelationship(string emailMainUser, string emailUserRemoved)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        var collection = database.GetCollection<User>(collectionName);
        var filterEmail = Builders<User>.Filter.Eq(r => r.Email, emailMainUser);
        
        var mainUser = await collection.Find(filterEmail).FirstOrDefaultAsync();
        var filterEmailUserRemoved = Builders<User>.Filter.Eq(r => r.Email, emailUserRemoved);
        var removedUser = await collection.Find(filterEmailUserRemoved).FirstOrDefaultAsync();

        if (mainUser == null || removedUser == null)
        {
            throw new Exception("Usuário não encontrado.");
        }
        else
        {
            var updateMainUser = Builders<User>.Update.Pull(user => user.Relacoes, removedUser.Email);
            var resultMainUser = await collection.UpdateOneAsync(filterEmail, updateMainUser, new UpdateOptions {IsUpsert = true});
            return mainUser;
        }
    }
    public async Task<List<string>> RecommendUsers(string email)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        var collection = database.GetCollection<User>(collectionName);

        var filterEmail = Builders<User>.Filter.Eq(r => r.Email, email);
        var mainUser = await collection.Find(filterEmail).FirstOrDefaultAsync();

        if (mainUser == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        var userRelations = mainUser.Relacoes;
        if (userRelations == null || !userRelations.Any())
        {
            throw new Exception("Usuário não tem relações existentes.");
        }

        var recommendations = new Dictionary<string, int>();

        foreach (var relationEmail in userRelations)
        {
            var filterRelation = Builders<User>.Filter.Eq(r => r.Email, relationEmail);
            var relationUser = await collection.Find(filterRelation).FirstOrDefaultAsync();

            if (relationUser != null && relationUser.Relacoes != null)
            {
                foreach (var rec in relationUser.Relacoes)
                {
                    if (rec != email && !userRelations.Contains(rec))
                    {
                        if (recommendations.ContainsKey(rec))
                        {
                            recommendations[rec]++;
                        }
                        else
                        {
                            recommendations[rec] = 1;
                        }
                    }
                }
            }
        }

        var recommendedUsers = recommendations
            .Where(r => r.Value >= 2)
            .Select(r => r.Key)
            .ToList();

        return recommendedUsers;
    }

} 