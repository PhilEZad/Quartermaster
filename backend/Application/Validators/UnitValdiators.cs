using System.Data;
using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class UnitValdiator : AbstractValidator<Unit>
{
    public UnitValdiator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}

public class UnitRequestValidator : AbstractValidator<UnitRequest>
{
    public UnitRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}