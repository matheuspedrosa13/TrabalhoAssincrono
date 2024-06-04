using Microsoft.AspNetCore.Mvc;
using TrabalhoDaniel.Infra.Services;
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

    /*HttpClient*/
    [HttpGet("httpClient/json/todos")]
    public async Task<string> GetAllExternalData()
    {
        return await _service.GetAllExternalDataAsync();
    }

    [HttpGet("httpClient/json/todos/{id}")]
    public async Task<IActionResult> GetOneExternalData(int id)
    {
        try
        {
            string httpClient = await _service.GetOneExternalDataAsync(id);
            return Ok(httpClient);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }

    /*RestSharp*/
    [HttpGet("RestSharp/json/todos")]
    public async Task<string> GetAllExternalDataWithRestSharpAsync()
    {
        return await _service.GetAllExternalDataWithRestSharpAsync();
    }

    [HttpGet("RestSharp/json/todos/{id}")]
    public async Task<IActionResult> GetOneExternalDataWithRestSharpAsync(int id)
    {
        try
        {
            string restSharp = await _service.GetOneExternalDataWithRestSharpAsync(id);
            return Ok(restSharp);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }

    /*FlurHttp*/
    [HttpGet("FlurHttp/json/todos")]
    public async Task<string> GetAllExternalDataWithFlurAsync()
    {
        return await _service.GetAllExternalDataWithFlurSharpAsync();
    }

    [HttpGet("FlurHttp/json/todos/{id}")]
    public async Task<IActionResult> GetOneExternalDataWithFlurAsync(int id)
    {
        try
        {
            string flurHttp = await _service.GetOneExternalDataWithFlurSharpAsync(id);
            return Ok(flurHttp);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }
}
