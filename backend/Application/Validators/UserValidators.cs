using Application.DTOs;
using Domain;
using FluentValidation;
using User = Domain.User;

namespace Application.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id cannot be null")
            .GreaterThan(0).WithMessage("Id must be greater than 0")
            .NotEmpty().WithMessage("Id cannot be empty");

        RuleFor(x => x.Username)
            .NotNull().WithMessage("Username can not be null")
            .NotEmpty().WithMessage("Username cannot be empty")
            .MinimumLength(3).WithMessage("Username must be more than 3 characters")
            .MaximumLength(20).WithMessage("Username may not more 20 characters")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Username must only contain alphanumeric characters, and can not contain spaces");

        RuleFor(x=> x.HasedPassword)
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");
    }
}