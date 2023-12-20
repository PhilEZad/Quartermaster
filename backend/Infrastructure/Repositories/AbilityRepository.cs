using Application.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

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

    public Ability UpdateAbility(Ability ability)
    {
        if (!_context.Abilities.Local.Any(f => f.Id == ability.Id))
        {
            _context.Attach(ability);
        }
        
        _context.Entry(ability).State = EntityState.Modified;
        _context.SaveChanges();
            
        return ability;
    }

    public bool DeleteAbility(int id)
    {
        var ability = _context.Abilities.Find(id) ??
                      throw new Exception("Ability not found");
        _context.Abilities.Remove(ability);
        var change =_context.SaveChanges();
        return change > 0;
    }
}