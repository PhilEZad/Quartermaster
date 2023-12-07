using Application.DTOs.Responses;
using Application.DTOs.Requests;
using Application.DTOs.Updates;
using Domain;

namespace Application.Interfaces.Services;

public interface IFactionService
{
    public FactionResponse CreateFaction(FactionRequest factionRequest);
    public List<FactionResponse> GetAllFactions();
    public FactionResponse GetFactionById(int id);
    public FactionResponse UpdateFaction(FactionUpdate factionRequestRequest);
    public Boolean DeleteFaction(int id);
}