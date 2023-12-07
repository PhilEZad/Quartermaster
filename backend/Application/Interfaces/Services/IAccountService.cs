using Application.DTOs;
using Application.DTOs.Requests;
using Domain;

namespace Application.Interfaces.Services;

public interface IAccountService
{
    public Boolean Create(RegisterRequest createAccount);
}