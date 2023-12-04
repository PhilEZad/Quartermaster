using Application.DTOs;
using Application.Interfaces;
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
        RegisterRequestValidator registerRequestValidator)
    {
        _accountRepository = accountRepository ?? throw new NullReferenceException("AccountRepository is null");
        
        _mapper = mapper ?? throw new NullReferenceException("Mapper is null");
        _passwordHasher = passwordHasher ?? throw new NullReferenceException("PasswordHasher is null");
        
        _userValidator = userValidator ?? throw new NullReferenceException("UserValidator is null");
        _accountDtoValidator = registerRequestValidator ?? throw new NullReferenceException("RegisterRequestDtoValidator is null");
    }

    public Boolean Create(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            throw new NullReferenceException("Register Request is null");
        }

        var validation = _accountDtoValidator.Validate(registerRequest);

        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        
        var user = _mapper.Map<User>(registerRequest);
        
        if (_accountRepository.DoesUserExist(user.Username))
            throw new Exception("User already exists");
        
        user.HasedPassword = _passwordHasher.Hash(registerRequest.password);
        user.DateCreated = DateTime.Now;
        
        User returnUser = _accountRepository.Create(user);
        
        if (returnUser == null)
            throw new NullReferenceException("Failed to create account");
        
        validation = _userValidator.Validate(returnUser);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return true;
    }
}