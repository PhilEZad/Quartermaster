using Domain;

namespace Application.Interfaces.Services;

public interface IFactionService
{
    public Faction CreateFaction(Faction faction);
    public Faction[] GetAllFactions();
    public Faction GetFactionById(int id);
    public Faction UpdateFaction(Faction faction);
    public Boolean DeleteFaction(int id);
}