using Application.DTOs;
using Application.DTOs.Responses;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class WeaponValidator : AbstractValidator<Weapon>
{
    public WeaponValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Range).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Strength).NotEmpty();
        RuleFor(x => x.ArmourPenetration).NotEmpty();
        RuleFor(x => x.Damage).NotEmpty();
        RuleFor(x => x.Points).NotEmpty();
    }
}

public class WeaponRequestValidator : AbstractValidator<WeaponRequest>
{
    public WeaponRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Range).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Strength).NotEmpty();
        RuleFor(x => x.ArmourPenetration).NotEmpty();
        RuleFor(x => x.Damage).NotEmpty();
        RuleFor(x => x.Points).NotEmpty();
    }
}

public class WeaponResponseValidator : AbstractValidator<WeaponResponse>
{
    public WeaponResponseValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Range).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Strength).NotEmpty();
        RuleFor(x => x.ArmourPenetration).NotEmpty();
        RuleFor(x => x.Damage).NotEmpty();
        RuleFor(x => x.Points).NotEmpty();
    }
}