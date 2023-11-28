using Application.Interfaces;


namespace Application.Services;

public class AccountService : IAccountService
{
    public readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new NullReferenceException();
    }
    
}