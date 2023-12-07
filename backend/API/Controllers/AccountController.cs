﻿using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService ?? throw new NullReferenceException("AccountService cannot be null");
    }
    
    [AllowAnonymous]
    [HttpPost]
    [Route(nameof(CreateUser))]
    public IActionResult CreateUser([FromBody] RegisterRequest registerRequest)
    {
        try
        {
            _accountService.Create(registerRequest);
            return Ok("Account Created");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}