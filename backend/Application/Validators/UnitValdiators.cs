using System.Data;
using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class UnitValdiator : AbstractValidator<Unit>
{
    public UnitValdiator()
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