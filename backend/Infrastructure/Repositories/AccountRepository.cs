using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    public User Create(RegisterRequest createAccount)
    {
        throw new NotImplementedException();
    }
}