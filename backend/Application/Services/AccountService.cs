using Application.DTOs.Requests;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain;


namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    private readonly IValidationHelper _validatorHelper;

    public AccountService(
        IAccountRepository accountRepository,
        IPasswordHasher passwordHasher,
        IMapper mapper,
        IValidationHelper validationHelper)
    {
        _accountRepository = accountRepository ?? throw new NullReferenceException("AccountRepository is null");

        _mapper = mapper ?? throw new NullReferenceException("Mapper is null");
        _passwordHasher = passwordHasher ?? throw new NullReferenceException("PasswordHasher is null");

        _validatorHelper = validationHelper ?? throw new NullReferenceException("ValidationHelper is null");
    }

    public Boolean Create(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            throw new NullReferenceException("RegisterRequest is null");
        }

        _validatorHelper.ValidateOrThrow(registerRequest);
        
        var user = _mapper.Map<User>(registerRequest);
        
        user.HasedPassword = _passwordHasher.Hash(registerRequest.password);
        user.DateCreated = DateTime.Now;
        user.DateModified = DateTime.Now;
        
        User returnUser = _accountRepository.Create(user, "User");

        if (returnUser == null)
        {
            throw new ArgumentException("Account could not be created. Please try again.");
        }
        
        return true;
    }
}