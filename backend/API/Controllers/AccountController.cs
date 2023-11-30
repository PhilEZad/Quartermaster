using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace DefaultNamespace;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private AccountController(IAccountService accountService)
    {
        _accountService = accountService ?? throw new NullReferenceException();
    }
    
    [HttpPost]
    public IActionResult Create(User user)
    {
        try
        {
            _accountService.Create(user);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}