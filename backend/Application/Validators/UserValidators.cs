using Application.DTO;
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

        RuleFor(x => x.username).NotNull().MinimumLength(3);
        RuleFor(x => x.username).MaximumLength(20).WithMessage("Username must be at most 20 characters long");
        RuleFor(x => x.username).NotEmpty().WithMessage("Username cannot be empty");
        RuleFor(x => x.username).Matches("^[a-zA-Z0-9]*$").WithMessage("Username must only contain alphanumeric characters, and can not contain spaces");
        
        RuleFor(x=> x.password).MinimumLength(8).WithMessage("Password must be at least 8 characters long");
    }
}

public class UserDTOValidator : AbstractValidator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(x => x.username).NotNull().MinimumLength(3);
        RuleFor(x => x.username).MaximumLength(20).WithMessage("Username must be at most 20 characters long");
        RuleFor(x => x.username).NotEmpty().WithMessage("Username cannot be empty");
        RuleFor(x => x.username).Matches("^[a-zA-Z0-9]*$").WithMessage("Username must only contain alphanumeric characters, and can not contain spaces");
        
        RuleFor(x=> x.password).MinimumLength(8).WithMessage("Password must be at least 8 characters long");
    }
}