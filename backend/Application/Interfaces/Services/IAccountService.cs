using Application.DTO;
using Domain;

namespace Application.Interfaces;

public interface IAccountService
{
    public User Create(UserDTO user);
}