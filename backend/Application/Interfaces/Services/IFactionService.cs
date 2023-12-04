using Application.DTOs;
using Domain;

namespace Application.Interfaces.Services;

public interface IFactionService
{
    public Faction CreateFaction(FactionRequest factionRequest);
    public List<Faction> GetAllFactions();
    public Faction GetFactionById(int id);
    public Faction UpdateFaction(Faction faction);
    public Boolean DeleteFaction(Faction faction);
}