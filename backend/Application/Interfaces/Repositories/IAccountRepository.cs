using Application.DTOs;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IAccountRepository
{
    User Create(User user, string type);
    Boolean DoesUserExist(string username);
    User GetUserByUsername(string loginRequestUsername);
}