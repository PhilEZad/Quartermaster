using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{

        public RegisterRequestValidator()
        {
            RuleFor(x => x.username).NotNull().MinimumLength(3);
            RuleFor(x => x.username).MaximumLength(20).WithMessage("Username must be at most 20 characters long");
            RuleFor(x => x.username).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(x => x.username).Matches("^[a-zA-Z0-9]*$").WithMessage("Username must only contain alphanumeric characters, and can not contain spaces");
        
            RuleFor(x=> x.password).MinimumLength(8).WithMessage("Password must be at least 8 characters long");
        }
}