using Application.DTOs;
using Application.DTOs.Responses;
using FluentValidation;

namespace Application.Validators;

public class LoginRequestValidators : AbstractValidator<LoginRequest>
{
    public LoginRequestValidators()
    {
        RuleFor(x => x.Username)
            .MinimumLength(4).WithMessage("Username must be at least 3 characters long")
            .MaximumLength(20).WithMessage("Username may not more 20 characters")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Username must only contain alphanumeric characters, and can not contain spaces");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password can not be empty");
    }
}

public class LoginResponseValidators : AbstractValidator<LoginResponse>
{
    public LoginResponseValidators()
    {
        RuleFor(x => x.Jwt)
            .NotEmpty().WithMessage("Token can not be empty");
        
        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("Message can not be empty");
    }
}