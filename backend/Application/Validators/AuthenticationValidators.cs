using Application.DTOs;
using Application.DTOs.Responses;
using FluentValidation;

namespace Application.Validators;

public class LoginRequestValidators : AbstractValidator<LoginRequest>
{
    public LoginRequestValidators()
    {
        
    }
}

public class LoginResponseValidators : AbstractValidator<LoginResponse>
{
    public LoginResponseValidators()
    {
        
    }
}