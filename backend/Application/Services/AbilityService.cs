using Application.DTOs;
using Application.DTOs.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application.Services;

public class AbilityService : IAbilityService
{
    private readonly IAbilityRepository _abilityRepository;
    private readonly IMapper _mapper;

    private readonly AbilityValidator _validator;
    private readonly AbilityRequestValidator _requestValidator;
    private readonly AbilityResponseValidator _responseValidator;

    public AbilityService(IAbilityRepository abilityRepository, IMapper mapper, AbilityValidator validator, AbilityRequestValidator requestValidator, AbilityResponseValidator responseValidator)
    {
        _abilityRepository = abilityRepository;
        _mapper = mapper;
        _validator = validator;
        _requestValidator = requestValidator;
        _responseValidator = responseValidator;
    }

    public AbilityResponse CreateAbility(AbilityRequest request)
    {
        if (request == null)
            throw new NullReferenceException("AbilityRequest cannot be null");
        
        var validationRequest = _requestValidator.Validate(request);
        if (!validationRequest.IsValid)
            throw new ValidationException(validationRequest.ToString());
        
        var ability = _mapper.Map<Ability>(request);

        var returnAbility = _abilityRepository.CreateAbility(ability);
        
        if (returnAbility == null)
            throw new NullReferenceException("AbilityResponse cannot be null");
        
        var abilityValidation = _validator.Validate(returnAbility);
        if (!abilityValidation.IsValid)
            throw new ValidationException(abilityValidation.ToString());
        
        var response = _mapper.Map<AbilityResponse>(returnAbility);
        
        var validationResponse = _responseValidator.Validate(response);
        
        if (!validationResponse.IsValid)
            throw new ValidationException(validationResponse.ToString());
        
        return response;
    }

    public AbilityResponse GetAbilityById(int id)
    {
        throw new NotImplementedException();
    }

    public List<AbilityResponse> GetAllAbilities()
    {
        List<Ability> returnList = _abilityRepository.GetAllAbilities();
        
        if (returnList == null)
            throw new NullReferenceException("Ability List can not be null");

        List< AbilityResponse> reponseList = _mapper.Map<List<AbilityResponse>>(returnList);
        
        return reponseList;
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