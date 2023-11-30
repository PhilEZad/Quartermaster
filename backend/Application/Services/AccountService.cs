using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;


namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;
    
    private readonly UserValidator _userValidator;
    private readonly RegisterRequestValidator _accountDtoValidator;

    public AccountService(
        IAccountRepository accountRepository,
        IPasswordHasher passwordHasher,
        IMapper mapper,
        UserValidator userValidator,
        RegisterRequestValidator accountDtoValidator)
    {
        _accountRepository = accountRepository ?? throw new NullReferenceException();
        
        _mapper = mapper ?? throw new NullReferenceException();
        _passwordHasher = passwordHasher ?? throw new NullReferenceException();
        
        _userValidator = userValidator ?? throw new NullReferenceException();
        _accountDtoValidator = accountDtoValidator ?? throw new NullReferenceException();
    }

    public Domain.User Create(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            throw new NullReferenceException();
        }

        var passwordHashed = _passwordHasher.Hash(registerRequest.password);

        var validation = _accountDtoValidator.Validate(registerRequest);

        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        
        
        
        User returnUser = _accountRepository.Create(null);
        
        validation = _userValidator.Validate(returnUser);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return returnUser;
    }
}