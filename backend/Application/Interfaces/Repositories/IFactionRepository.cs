using Domain;

namespace Application.Interfaces.Repositories;

public interface IFactionRepository
{
    public Faction CreateFaction(Faction faction);
    public List<Faction> GetAllFactions();
    public Faction GetFactionById(int id);
    public Faction UpdateFaction(Faction faction);
    public Boolean DeleteFaction(Faction faction);
}