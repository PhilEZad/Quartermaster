using Application.DTO;
using Application.Interfaces;
using Domain;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    public User create(UserDTO user)
    {
        throw new NotImplementedException();
    }
}