using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class FactionRepository : IFactionRepository
{
    DatabaseContext _context;

    public FactionRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Faction CreateFaction(Faction faction)
    {
        throw new NotImplementedException();
    }

    public List<Faction> GetAllFactions()
    {
        return _context.Factions.ToList();
    }

    public Faction GetFactionById(int id)
    {
        throw new NotImplementedException();
    }

    public Faction UpdateFaction(Faction faction)
    {
        throw new NotImplementedException();
    }

    public bool DeleteFaction(Faction faction)
    {
        throw new NotImplementedException();
    }
}