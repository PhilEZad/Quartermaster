using Application.DTOs;
using Application.DTOs.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Validators;
using AutoMapper;

namespace Application.Services;

public class AbilityService : IAbilityService
{
    private readonly IAbilityRepository _abilityRepository;
    private readonly IMapper _mapper;

    private readonly AbilityValidator _validator;
    private readonly AbilityRequestValidator _requestValidator;
    private readonly AbilityResponseValidator _responseValidator;
    
    public AbilityResponse CreateAbility(AbilityRequest abilityRequest)
    {
        throw new NotImplementedException();
    }

    public AbilityResponse GetAbilityById(int id)
    {
        throw new NotImplementedException();
    }

    public List<AbilityResponse> GetAllAbilities()
    {
        throw new NotImplementedException();
    }

    public AbilityResponse UpdateAbility(AbilityRequest abilityRequest)
    {
        throw new NotImplementedException();
    }

    public bool DeleteAbility(int id)
    {
        throw new NotImplementedException();
    }
}