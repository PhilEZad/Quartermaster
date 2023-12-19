using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain;

namespace Application.Services;

public class AbilityService : IAbilityService
{
    private readonly IAbilityRepository _abilityRepository;
    private readonly IMapper _mapper;
    private readonly IValidationHelper _validationHelper;

    public AbilityService(IAbilityRepository abilityRepository, IMapper mapper, IValidationHelper validationHelper)
    {
        _abilityRepository = abilityRepository ?? throw new NullReferenceException("AbilityRepository is null");
        _mapper = mapper ?? throw new NullReferenceException("Mapper is null");
        _validationHelper = validationHelper ?? throw new NullReferenceException("ValidationHelper is null");
    }

    public AbilityResponse CreateAbility(AbilityRequest request)
    {
        if (request == null)
            throw new NullReferenceException("AbilityRequest cannot be null");
        
        _validationHelper.ValidateOrThrow(request);
        
        var ability = _mapper.Map<Ability>(request);

        var returnAbility = _abilityRepository.CreateAbility(ability);
        
        if (returnAbility == null)
            throw new NullReferenceException("AbilityResponse cannot be null");
        
        _validationHelper.ValidateOrThrow(returnAbility);
        
        var response = _mapper.Map<AbilityResponse>(returnAbility);

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

        List<AbilityResponse> reponseList = _mapper.Map<List<AbilityResponse>>(returnList);
        
        return reponseList;
    }

    public AbilityResponse UpdateAbility(AbilityRequest abilityRequest)
    {
        throw new NotImplementedException();
    }

    public bool DeleteAbility(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id is invalid");
        
        return _abilityRepository.DeleteAbility(id);
    }
}