using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application.Services;

public class FactionService : IFactionService
{
    private readonly IFactionRepository _factionRepository;
    private readonly IMapper _mapper;
    
    private readonly FactionValidator _validators;
    private readonly FactionRequestValidators _requestValidators;
    private readonly FactionResponseValidators _responseValidators;
    
    public FactionService(
       IFactionRepository factionRepository,
       IMapper mapper,
        
       FactionValidator validator,
       FactionRequestValidators requestValidators,
       FactionResponseValidators responseValidators
    )
    {
       _factionRepository = factionRepository ?? throw new NullReferenceException("FactionRepository is null");
       _mapper = mapper ?? throw new NullReferenceException("Mapper is null");
        
       _validators = validator ?? throw new NullReferenceException("FactionValidators is null");
       _requestValidators = requestValidators ?? throw new NullReferenceException("FactionRequestValidators is null");
       _responseValidators = responseValidators ?? throw new NullReferenceException("FactionResponseValidators is null");
    }
    
    public Faction CreateFaction(FactionRequest factionRequest)
    {
        if (factionRequest == null)
            throw new NullReferenceException("FactionRequest is null");
        
        var validation = _requestValidators.Validate(factionRequest);
        
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        
        var faction = _mapper.Map<Faction>(factionRequest);
        
        var createdFaction = _factionRepository.CreateFaction(faction);
        
        if (createdFaction == null)
            throw new Exception("Faction could not be created");
        
        var validatedFaction = _validators.Validate(createdFaction);
        
        if (validatedFaction.IsValid)
            throw new ValidationException(validatedFaction.ToString());
        
        return createdFaction;
    }

    public List<Faction> GetAllFactions()
    {
        List<Faction> factionList = _factionRepository.GetAllFactions();
        
        if (factionList == null || factionList.Count == 0)
            throw new Exception("No factions found");
        
        return factionList;
    }

    public Faction GetFactionById(int id)
    {
        if (id <= 0)
            throw new Exception("Id is invalid");
        
        Faction faction = _factionRepository.GetFactionById(id);
        
        if (faction == null)
            throw new Exception("No faction found");
        
        var validatedFaction = _validators.Validate(faction);
        
        if (validatedFaction.IsValid)
            throw new ValidationException(validatedFaction.ToString());
        
        return faction;
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