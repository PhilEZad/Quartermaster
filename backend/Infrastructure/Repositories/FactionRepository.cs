using Application.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FactionRepository : IFactionRepository
{
    private readonly DatabaseContext _context;

    public FactionRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Faction CreateFaction(Faction faction)
    {
        _context.Factions.Add(faction);
        _context.SaveChanges();
        
        return faction;
    }

    public List<Faction> GetAllFactions()
    {
        return _context.Factions.ToList();
    }

    public Faction GetFactionById(int id)
    {
        return _context.Factions.Find(id);
    }

    public Faction UpdateFaction(Faction faction)
    {
        _context.Factions.Update(faction);
        var change = _context.SaveChanges();
        
        if (change == 0)
            throw new Exception("Faction could not be updated");
        
        return faction;
    }

    public bool DeleteFaction(Faction faction)
    {
        _context.Factions.Remove(faction);
        var change =_context.SaveChanges();
        return change > 0;
    }
}