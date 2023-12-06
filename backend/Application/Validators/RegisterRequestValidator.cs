using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{

        public RegisterRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            
            RuleFor(x => x.username)
                .NotNull().WithMessage("Username cannot be null")
                .NotEmpty().WithMessage("Username cannot be empty")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long")
                .Matches("^[a-zA-Z0-9]*$").WithMessage("Username must only contain alphanumeric characters, and can not contain spaces");

            RuleFor( x => x.email)
                .NotNull().WithMessage("Email cannot be null")
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("A valid email address is required");
            
            RuleFor(x=> x.password)
                .NotNull().WithMessage("Password can not be null")
                .NotEmpty().WithMessage("Password can not be empty")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long");
        }
}