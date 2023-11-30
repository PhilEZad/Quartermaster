using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Services;
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
    public IActionResult Create(RegisterRequest registerRequest)
    {
        try
        {
            _accountService.Create(registerRequest);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}