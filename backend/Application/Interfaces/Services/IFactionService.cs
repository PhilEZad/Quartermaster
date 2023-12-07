using Application.DTOs;
using Application.DTOs.Responses;
using Domain;

namespace Application.Interfaces.Services;

public interface IFactionService
{
    public FactionResponse CreateFaction(FactionRequest factionRequest);
    public List<FactionResponse> GetAllFactions();
    public FactionResponse GetFactionById(int id);
    public FactionResponse UpdateFaction(Faction factionRequest);
    public Boolean DeleteFaction(Faction factionRequest);
}