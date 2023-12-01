using Application.DTOs;
using Application.DTOs.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Validators;
using AutoMapper;

namespace Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    
    private readonly LoginRequestValidators _loginRequestValidator;
    private readonly LoginResponseValidators _loginResponseValidator;
    private readonly UserValidator _userValidator;

    public AuthenticationService(
        IAccountRepository accountRepository,
        IMapper mapper,
        
        LoginRequestValidators loginRequestValidator,
        LoginResponseValidators loginResponseValidator,
        UserValidator userValidator)
    {
        _accountRepository = accountRepository ?? throw new NullReferenceException("AccountRepository is null");
        _mapper = mapper == null ? throw new NullReferenceException("Mapper is null") : mapper;
        
        _loginRequestValidator = loginRequestValidator ?? throw new NullReferenceException("LoginRequestValidator is null");
        _loginResponseValidator = loginResponseValidator ?? throw new NullReferenceException("LoginResponseValidator is null");
        _userValidator = userValidator ?? throw new NullReferenceException("UserValidator is null");
    }

    public LoginResponse Login(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }
}