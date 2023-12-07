using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Interfaces.Services;

public interface IAuthenticationService
{
    public LoginResponse Login(LoginRequest loginRequest);
}