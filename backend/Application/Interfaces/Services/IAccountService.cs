using Application.DTOs;
using Domain;

namespace Application.Interfaces.Services;

public interface IAccountService
{
    public User Create(RegisterRequest createAccount);
}