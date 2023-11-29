using Domain;
using FluentValidation;

namespace Application.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.id).NotNull().WithMessage("Id cannot be null");
        RuleFor(x => x.id).GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(x => x.id).NotEmpty().WithMessage("Id cannot be empty");

        RuleFor(x => x.userName).NotNull().MinimumLength(3);
        RuleFor(x => x.userName).MaximumLength(20).WithMessage("Username must be at most 20 characters long.");
        RuleFor(x => x.userName).NotEmpty().WithMessage("Username cannot be empty");
        RuleFor(x => x.userName).Matches("^[a-zA-Z0-9]*$").WithMessage("Username must only contain alphanumeric characters, and can not contain spaces.");
        
        RuleFor(x => x.password).NotNull().WithMessage("Password cannot be null");
        RuleFor(x => x.password).NotEmpty().WithMessage("Password cannot be empty");
        RuleFor(x=> x.password).MinimumLength(3).WithMessage("Password must be at least 3 characters long.");
    }
}