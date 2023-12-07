using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IAbilityRepository
{
    public Ability CreateAbility(Ability ability);
    
    public Ability GetAbilityById(int id);
    public List<Ability> GetAllAbilities();
    
    public Ability UpdateAbility(AbilityRequest request);
    
    public Boolean DeleteAbility(int id);
}