using Application.DTOs;
using Application.DTOs.Responses;

namespace Application.Interfaces.Services;

public interface IAbilityService
{
    public AbilityResponse CreateAbility(AbilityRequest abilityRequest);
    
    public AbilityResponse GetAbilityById(int id);
    public List<AbilityResponse> GetAllAbilities();
    
    public AbilityResponse UpdateAbility(AbilityRequest abilityRequest);
    
    public Boolean DeleteAbility(int id);
}