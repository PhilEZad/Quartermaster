using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class DatabaseController : ControllerBase
{
    private readonly IDatabase _database;
    
    public DatabaseController(IDatabase database)
    {
        _database = database ?? throw new NullReferenceException();
    }
    
    [HttpGet]
    [Route("buildDB")]
    public string BuildDb()
    {
        _database.BuildDb();
        return "Database built";
    }
}