using Application.DTOs.Responses;
using Application.DTOs.Updates;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class FactionValidator : AbstractValidator<Faction>
{
    public FactionValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name can not be null")
            .NotEmpty().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name can not be more than 50 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description can not be empty");
    }
    
}

public class FactionRequestValidator : AbstractValidator<DTOs.Requests.FactionRequest>
{
    public FactionRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name can not be null")
            .NotEmpty().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name can not be more than 50 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description can not be empty");
    }
}

public class FactionResponseValidator : AbstractValidator<FactionResponse>
{
    public FactionResponseValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name can not be null")
            .NotEmpty().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name can not be more than 50 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description can not be empty");
    }
}

public class FactionUpdateValidator : AbstractValidator<FactionUpdate>
{
    public FactionUpdateValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id can not be null")
            .NotEmpty().WithMessage("Id can not be empty")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name can not be null")
            .NotEmpty().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name can not be more than 50 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description can not be empty");
    }
}