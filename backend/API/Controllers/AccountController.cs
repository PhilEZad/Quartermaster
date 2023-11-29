using Application.Interfaces;
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
}