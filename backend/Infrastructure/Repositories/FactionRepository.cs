﻿using Application.Interfaces.Repositories;
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
        if (!_context.Factions.Local.Any(f => f.Id == faction.Id))
        {
            _context.Attach(faction);
        }
        
        _context.Entry(faction).State = EntityState.Modified;
        _context.SaveChanges();
            
        return faction;
    }

    public bool DeleteFaction(int id)
    {
        var faction = _context.Factions.Find(id) ??
                      throw new Exception("Faction not found");
        _context.Factions.Remove(faction);
        var change =_context.SaveChanges();
        return change > 0;
    }
}