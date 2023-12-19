using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class UnitValidator : AbstractValidator<Unit>
{
    public UnitValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required");
    }
}

public class UnitRequestValidator : AbstractValidator<UnitRequest>
{
    public UnitRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required");
    }
}

public class UnitResponseValidator : AbstractValidator<UnitResponse>
{
    public UnitResponseValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required");
    }
}