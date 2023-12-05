using Application.DTOs;
using Application.DTOs.Responses;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IAbilityRepository
{
    public Ability CreateAbility(Ability request);
    
    public Ability GetAbilityById(int id);
    public List<AbilityResponse> GetAllAbilities();
    
    public Ability UpdateAbility(AbilityRequest request);
    
    public Boolean DeleteAbility(int id);
}