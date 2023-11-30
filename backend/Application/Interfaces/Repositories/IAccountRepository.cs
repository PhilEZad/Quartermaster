using Application.DTOs;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IAccountRepository
{
    User Create(RegisterRequest createAccount);

}