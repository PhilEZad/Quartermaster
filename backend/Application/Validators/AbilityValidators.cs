using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class AbilityValidator : AbstractValidator<Ability>
{
    
}

public class AbilityRequestValidator : AbstractValidator<AbilityRequest>
{
    public AbilityRequestValidator()
    {

    }
}

public class AbilityResponseValidator : AbstractValidator<AbilityResponse>
{
    public AbilityResponseValidator()
    {
        
    }
}