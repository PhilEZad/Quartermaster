using Application.DTOs;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IAccountRepository
{
    User Create(User user);
    Boolean DoesUserExist(string username);
}