using Microsoft.AspNetCore.Mvc;
using TrabalhoDaniel.Repo.Entities;
using TrabalhoDaniel.Service.Services;

namespace TrabalhoDaniel.Controllers;
[ApiController]
[Route("api/")]
public class Controller : ControllerBase
{
    private readonly IService _service;

    public Controller(IService service)
    {
        _service = service;
    }
    [HttpPost("TrabalhoAsync/PostUser/")]
    public async Task<User> PostUser()
    {
        return await _service.PostUser();
    }

    [HttpGet("TrabalhoAsync/GetUser/{email}")]
    public async Task<User> GetUser(string email)
    {   
        try
        {
            return await _service.GetUser(email);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Um erro encontrado: {ex.Message}");
            throw;
        }
    }

    [HttpGet("TrabalhoAsync/Login/{email}/{password}")]
    public async Task<bool?> LoginUser(string email, string password)
    {   
        try
        {
            return await _service.LoginUser(email, password);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Um erro encontrado: {ex.Message}");
            throw;
        }
    }

    [HttpGet("TrabalhoAsync/Logout/{email}")]
    public async Task<bool?> Logout(string email)
    {   
        try
        {
            return await _service.LogoutUser(email);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Um erro encontrado: {ex.Message}");
            throw;
        }
    }

    [HttpPut("TrabalhoAsync/CreateRelationship/{emailMainUser}/{emailAddedUser}")]
    public async Task<User> CreateRelationship(string emailMainUser, string emailAddedUser)
    {   
        try
        {
            return await _service.CreateRelationship(emailMainUser, emailAddedUser);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Um erro encontrado: {ex.Message}");
            throw;
        }
    }

    [HttpPut("TrabalhoAsync/RemoveRelationship/{emailMainUser}/{emailRemoveUser}")]
    public async Task<User> RemoveRelationship(string emailMainUser, string emailRemoveUser)
    {   
        try
        {
            return await _service.RemoveRelationShip(emailMainUser, emailRemoveUser);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Um erro encontrado: {ex.Message}");
            throw;
        }
    }

    [HttpGet("TrabalhoAsync/RecommendationUser/{emailMainUser}")]
    public async Task<List<string>> RecommendationUser(string emailMainUser)
    {   
        try
        {
            return await _service.RecommedationUser(emailMainUser);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Um erro encontrado: {ex.Message}");
            throw;
        }
    }

    [HttpGet("TrabalhoAsync/RelationsUser/{emailMainUser}")]
    public async Task<List<string>> RelationsUser(string emailMainUser)
    {   
        try
        {
            return await _service.GetUserRelations(emailMainUser);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Um erro encontrado: {ex.Message}");
            throw;
        }
    }

    [HttpGet("TrabalhoAsync/GetAllUser/")]
    public async Task<List<User>> GetAllUser()
    {   
        try
        {
            return await _service.GetAllUser();
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Um erro encontrado: {ex.Message}");
            throw;
        }
    }
}
