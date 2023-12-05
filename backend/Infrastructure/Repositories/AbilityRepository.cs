using Application.DTOs;
using Application.DTOs.Responses;
using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class AbilityRepository : IAbilityRepository
{
    private readonly DatabaseContext _context;
    
    public AbilityRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Ability CreateAbility(Ability request)
    {
        throw new NotImplementedException();
    }

    public Ability GetAbilityById(int id)
    {
        throw new NotImplementedException();
    }

    public List<AbilityResponse> GetAllAbilities()
    {
        throw new NotImplementedException();
    }

    public Ability UpdateAbility(AbilityRequest request)
    {
        throw new NotImplementedException();
    }

    public bool DeleteAbility(int id)
    {
        throw new NotImplementedException();
    }
}