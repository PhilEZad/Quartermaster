﻿using Application.DTOs;
using Application.DTOs.Responses;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Validators;
using AutoMapper;
using FluentValidation;

namespace Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher _passwordHasher;
    
    private readonly LoginRequestValidators _loginRequestValidator;
    private readonly LoginResponseValidators _loginResponseValidator;
    private readonly UserValidator _userValidator;

    public AuthenticationService(
        IAccountRepository accountRepository,
        IMapper mapper,
        IJwtProvider jwtProvider,
        IPasswordHasher passwordHasher,
        
        LoginRequestValidators loginRequestValidator,
        LoginResponseValidators loginResponseValidator,
        UserValidator userValidator)
    {
        _accountRepository = accountRepository ?? throw new NullReferenceException("AccountRepository is null");
        _mapper = mapper ?? throw new NullReferenceException("Mapper is null");
        _jwtProvider = jwtProvider ?? throw new NullReferenceException("JwtProvider is null");
        _passwordHasher = passwordHasher ?? throw new NullReferenceException("PasswordHasher is null");
        
        _loginRequestValidator = loginRequestValidator ?? throw new NullReferenceException("LoginRequestValidator is null");
        _loginResponseValidator = loginResponseValidator ?? throw new NullReferenceException("LoginResponseValidator is null");
        _userValidator = userValidator ?? throw new NullReferenceException("UserValidator is null");
    }

    public LoginResponse Login(LoginRequest loginRequest)
    {
        if (loginRequest == null)
            throw new NullReferenceException("Login Request is null");

        var validation = _loginRequestValidator.Validate(loginRequest);
        
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        var user = _accountRepository.GetUserByUsername(loginRequest.Username);
        
        if (user == null)
            throw new Exception("User not found");
        
        if (!_passwordHasher.Verify(user.HasedPassword, loginRequest.Password))
            throw new Exception("Password is incorrect");

        var validationUser = _userValidator.Validate(user);
        
        if (!validationUser.IsValid)
            throw new ValidationException(validationUser.ToString());
        
        LoginResponse loginResponse = new LoginResponse
        {
            Jwt = _jwtProvider.GenerateToken(user),
            Message = "Login successful"
        };

        return loginResponse;
    }
}