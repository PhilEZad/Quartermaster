using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Validators;
using Domain;
using FluentValidation;


namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly UserValidator _userValidator;
    private readonly CreateAccountValidator _accountDtoValidator;
    private readonly IPasswordHasher _passwordHasher;
    
    public AccountService(IAccountRepository accountRepository, UserValidator userValidator, CreateAccountValidator accountDtoValidator, IPasswordHasher passwordHasher)
    {
        _accountRepository = accountRepository ?? throw new NullReferenceException();
        _userValidator = userValidator ?? throw new NullReferenceException();
        _accountDtoValidator = accountDtoValidator ?? throw new NullReferenceException();
        _passwordHasher = passwordHasher ?? throw new NullReferenceException();
    }

    public User Create(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            throw new NullReferenceException();
        }

        var passwordHashed = _passwordHasher.Hash(registerRequest.password);

        var validation = _accountDtoValidator.Validate(registerRequest);

        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        
        User returnUser = _accountRepository.Create(registerRequest);
        
        validation = _userValidator.Validate(returnUser);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return returnUser;
    }
}