using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.DTOs.Updates;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class WeaponValidator : AbstractValidator<Weapon>
{
    public WeaponValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is null")
            .NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Faction)
            .NotNull().WithMessage("Faction is null")
            .NotEmpty().WithMessage("Faction is required");
        RuleFor(x => x.Range)
            .NotNull().WithMessage("Range is null")
            .NotEmpty().WithMessage("Range is required");
        RuleFor(x => x.Type)
            .NotNull().WithMessage("Type is null")
            .NotEmpty().WithMessage("Type is required");
        RuleFor(x => x.Strength)
            .NotNull().WithMessage("Strength is null")
            .NotEmpty().WithMessage("Strength is required");
        RuleFor(x => x.ArmourPenetration)
            .NotNull().WithMessage("ArmourPenetration is null")
            .NotEmpty().WithMessage("ArmourPenetration is required");
        RuleFor(x => x.Damage)
            .NotNull().WithMessage("Damage is null")
            .NotEmpty().WithMessage("Damage is required");
        RuleFor(x => x.Points)
            .NotNull().WithMessage("Points is null")
            .NotEmpty().WithMessage("Points are required");
        RuleFor(x => x.Abilities)
            .NotNull().WithMessage("Abilities is null");
    }
}

public class WeaponRequestValidator : AbstractValidator<WeaponRequest>
{
    public WeaponRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Faction)
            .NotNull().WithMessage("Faction is null")
            .NotEmpty().WithMessage("Faction is required");
        RuleFor(x => x.Range)
            .NotNull().WithMessage("Range is null")
            .NotEmpty().WithMessage("Range is required");
        RuleFor(x => x.Type)
            .NotNull().WithMessage("Type is null")
            .NotEmpty().WithMessage("Type is required");
        RuleFor(x => x.Strength)
            .NotNull().WithMessage("Strength is null")
            .NotEmpty().WithMessage("Strength is required");
        RuleFor(x => x.ArmourPenetration)
            .NotNull().WithMessage("ArmourPenetration is null")
            .NotEmpty().WithMessage("ArmourPenetration is required");
        RuleFor(x => x.Damage)
            .NotNull().WithMessage("Damage is null")
            .NotEmpty().WithMessage("Damage is required");
        RuleFor(x => x.Points)
            .NotNull().WithMessage("Points is null")
            .NotEmpty().WithMessage("Points are required");
        RuleFor(x => x.Abilities)
            .NotNull().WithMessage("Abilities is null");
    }
}

public class WeaponResponseValidator : AbstractValidator<WeaponResponse>
{
    public WeaponResponseValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is null")
            .NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Faction)
            .NotNull().WithMessage("Faction is null")
            .NotEmpty().WithMessage("Faction is required");
        RuleFor(x => x.Range)
            .NotNull().WithMessage("Range is null")
            .NotEmpty().WithMessage("Range is required");
        RuleFor(x => x.Type)
            .NotNull().WithMessage("Type is null")
            .NotEmpty().WithMessage("Type is required");
        RuleFor(x => x.Strength)
            .NotNull().WithMessage("Strength is null")
            .NotEmpty().WithMessage("Strength is required");
        RuleFor(x => x.ArmourPenetration)
            .NotNull().WithMessage("ArmourPenetration is null")
            .NotEmpty().WithMessage("ArmourPenetration is required");
        RuleFor(x => x.Damage)
            .NotNull().WithMessage("Damage is null")
            .NotEmpty().WithMessage("Damage is required");
        RuleFor(x => x.Points)
            .NotNull().WithMessage("Points is null")
            .NotEmpty().WithMessage("Points are required");
        RuleFor(x => x.Abilities)
            .NotNull().WithMessage("Abilities is null");
    }
}

public class WeaponUpdateValidator : AbstractValidator<WeaponUpdate>
{
    public WeaponUpdateValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is null")
            .NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Faction)
            .NotNull().WithMessage("Faction is null")
            .NotEmpty().WithMessage("Faction is required");
        RuleFor(x => x.Range)
            .NotNull().WithMessage("Range is null")
            .NotEmpty().WithMessage("Range is required");
        RuleFor(x => x.Type)
            .NotNull().WithMessage("Type is null")
            .NotEmpty().WithMessage("Type is required");
        RuleFor(x => x.Strength)
            .NotNull().WithMessage("Strength is null")
            .NotEmpty().WithMessage("Strength is required");
        RuleFor(x => x.ArmourPenetration)
            .NotNull().WithMessage("ArmourPenetration is null")
            .NotEmpty().WithMessage("ArmourPenetration is required");
        RuleFor(x => x.Damage)
            .NotNull().WithMessage("Damage is null")
            .NotEmpty().WithMessage("Damage is required");
        RuleFor(x => x.Points)
            .NotNull().WithMessage("Points is null")
            .NotEmpty().WithMessage("Points are required");
        RuleFor(x => x.Abilities)
            .NotNull().WithMessage("Abilities is null");
    }
}