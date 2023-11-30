using Application.DTO;
using Domain;

namespace Application.Interfaces;

public interface IAccountRepository
{
    User create(UserDTO user);

}