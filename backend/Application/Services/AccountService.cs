using Application.Interfaces;
using Domain;


namespace Application.Services;

public class AccountService : IAccountService
{
    public readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new NullReferenceException();
    }

    public bool Create(User user)
    {
        _accountRepository.create(user);
    }
}