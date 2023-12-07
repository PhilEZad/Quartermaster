using Application.DTOs;
using Application.DTOs.Responses;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class FactionValidator : AbstractValidator<Faction>
{
    public FactionValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Name)
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
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name can not be more than 50 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description can not be empty");
    }
}