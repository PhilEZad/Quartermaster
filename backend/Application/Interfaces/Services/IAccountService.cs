using Application.DTOs;
using Domain;

namespace Application.Interfaces.Services;

public interface IAccountService
{
    public Domain.User Create(RegisterRequest createAccount);
}