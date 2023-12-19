using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class AbilityValidator : AbstractValidator<Ability>
{
    public AbilityValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is invalid")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name can not be null")
            .NotEmpty().WithMessage("Name can not be empty")
            .MaximumLength(20).WithMessage("Name may not more 20 characters")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Name must only contain alphanumeric characters, and can not contain spaces");

        RuleFor(x => x.Description)
            .NotNull().WithMessage("Description can not be null")
            .MaximumLength(255).WithMessage("Description may not more 255 characters");
    }
}

public class AbilityRequestValidator : AbstractValidator<AbilityRequest>
{
    public AbilityRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is empty")
            .MaximumLength(20).WithMessage("Name may not more 20 characters")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Name must only contain alphanumeric characters, and can not contain spaces");

        RuleFor(x => x.Description)
            .NotNull().WithMessage("Description is null")
            .MaximumLength(255).WithMessage("Description may not more 255 characters");
    }
}

public class AbilityResponseValidator : AbstractValidator<AbilityResponse>
{
    public AbilityResponseValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is invalid")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is empty")
            .MaximumLength(20).WithMessage("Name may not more 20 characters")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Name must only contain alphanumeric characters, and can not contain spaces");

        RuleFor(x => x.Description)
            .NotNull().WithMessage("Description can not be null")
            .MaximumLength(255).WithMessage("Description may not more 255 characters");
    }
}