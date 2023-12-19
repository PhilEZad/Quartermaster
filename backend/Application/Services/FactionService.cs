using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.DTOs.Updates;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Validators;
using AutoMapper;
using Domain;

namespace Application.Services;

public class FactionService : IFactionService
{
    private readonly IFactionRepository _factionRepository;
    private readonly IMapper _mapper;
    
    private readonly IValidationHelper _validationHelper;

    
    public FactionService(
       IFactionRepository factionRepository,
       IMapper mapper,
       IValidationHelper validationHelper)
    {
       _factionRepository = factionRepository ?? throw new NullReferenceException("FactionRepository is null");
       _mapper = mapper ?? throw new NullReferenceException("Mapper is null");
       _validationHelper = validationHelper ?? throw new NullReferenceException("ValidationHelper is null");
    }
    
    public FactionResponse CreateFaction(FactionRequest factionRequest)
    {
        if (factionRequest == null)
            throw new NullReferenceException("FactionRequest is null");
        
        _validationHelper.ValidateOrThrow(factionRequest);
        var faction = _mapper.Map<Faction>(factionRequest);
        
        var createdFaction = _factionRepository.CreateFaction(faction);
        
        if (createdFaction == null)
            throw new NullReferenceException("Return Faction is null");        
        
        _validationHelper.ValidateOrThrow(createdFaction);
        
        FactionResponse response = _mapper.Map<FactionResponse>(createdFaction);
        return response;
    }

    public List<FactionResponse> GetAllFactions()
    {
        List<Faction> factionList = _factionRepository.GetAllFactions();
        
        if (factionList == null)
            throw new Exception("No factions found");
        
        List<FactionResponse> reponseList = _mapper.Map<List<FactionResponse>>(factionList);
        
        return reponseList;
    }

    public FactionResponse GetFactionById(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id is invalid");
        
        Faction faction = _factionRepository.GetFactionById(id);
        _validationHelper.ValidateOrThrow(faction);

        FactionResponse response = _mapper.Map<FactionResponse>(faction);

        return response;
    }

    public FactionResponse UpdateFaction(FactionUpdate faction)
    {
        if (faction == null)
            throw new NullReferenceException("FactionUpdate is null");
        
        _validationHelper.ValidateOrThrow(faction);
        
        Faction factionToUpdate = _mapper.Map<Faction>(faction);
        
        Faction updatedFaction = _factionRepository.UpdateFaction(factionToUpdate);
        
        if (updatedFaction == null)
            throw new NullReferenceException("Return Faction is null");
        
        _validationHelper.ValidateOrThrow(updatedFaction);
        
        FactionResponse response = _mapper.Map<FactionResponse>(updatedFaction);
        
        return response;
    }

    public bool DeleteFaction(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id is invalid");


        if (!_factionRepository.DeleteFaction(id))
            throw new ArgumentException("Faction could not be deleted");

        return true;
    }
}