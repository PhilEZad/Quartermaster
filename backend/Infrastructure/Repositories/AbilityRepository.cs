using Application.DTOs;
using Application.DTOs.Requests;
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

    public Ability CreateAbility(Ability ability)
    {
        _context.Abilities.Add(ability);
        _context.SaveChanges();
        
        return ability;
    }

    public Ability GetAbilityById(int id)
    {
        return _context.Abilities.FirstOrDefault(a => a.Id == id);
    }

    public List<Ability> GetAllAbilities()
    {
        return _context.Abilities.ToList();
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