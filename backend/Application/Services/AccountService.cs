using Application.DTO;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentValidation;


namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly UserValidator _userValidator;
    private readonly UserDTOValidator _userDTOValidator;
    
    public AccountService(IAccountRepository accountRepository, UserValidator userValidator, UserDTOValidator userDtoValidator)
    {
        _accountRepository = accountRepository ?? throw new NullReferenceException();
        _userValidator = userValidator ?? throw new NullReferenceException();
        _userDTOValidator = userDtoValidator ?? throw new NullReferenceException();
    }

    public User Create(UserDTO userDto)
    {
        if (userDto == null)
        {
            throw new NullReferenceException();
        }

        var validation = _userDTOValidator.Validate(userDto);

        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        
           User returnUser = _accountRepository.create(userDto);
        
        validation = _userValidator.Validate(returnUser);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return returnUser;
    }
}