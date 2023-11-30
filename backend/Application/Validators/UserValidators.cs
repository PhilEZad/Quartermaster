using Application.DTOs;
using Domain;
using FluentValidation;
using User = Domain.User;

namespace Application.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Id cannot be null");
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");

        RuleFor(x => x.Username).NotNull().MinimumLength(3);
        RuleFor(x => x.Username).MaximumLength(20).WithMessage("Username must be at most 20 characters long");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty");
        RuleFor(x => x.Username).Matches("^[a-zA-Z0-9]*$").WithMessage("Username must only contain alphanumeric characters, and can not contain spaces");
        
        RuleFor(x=> x.HashedPassword).MinimumLength(8).WithMessage("Password must be at least 8 characters long");
    }
}