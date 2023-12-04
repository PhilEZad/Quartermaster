using Application.DTOs;
using Application.DTOs.Responses;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class FactionValidator : AbstractValidator<Faction>
{
    public FactionValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name can not be more than 50 characters")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Name must only contain alphanumeric characters");
    }
    
}

public class FactionRequestValidators : AbstractValidator<FactionRequest>
{
    public FactionRequestValidators()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name can not be more than 50 characters")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Name must only contain alphanumeric characters");
    }
}

public class FactionResponseValidators : AbstractValidator<FactionResponse>
{
    public FactionResponseValidators()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name can not be more than 50 characters")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Name must only contain alphanumeric characters");
    }
}