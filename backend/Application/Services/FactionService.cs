﻿using Application.DTOs;
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
    
    private readonly FactionValidator _validator;
    private readonly FactionRequestValidator _requestValidator;
    private readonly FactionResponseValidator _responseValidator;
    
    public FactionService(
       IFactionRepository factionRepository,
       IMapper mapper,
        
       FactionValidator validator,
       FactionRequestValidator requestValidator,
       FactionResponseValidator responseValidator
    )
    {
       _factionRepository = factionRepository ?? throw new NullReferenceException("FactionRepository is null");
       _mapper = mapper ?? throw new NullReferenceException("Mapper is null");
        
       _validator = validator ?? throw new NullReferenceException("FactionValidators is null");
       _requestValidator = requestValidator ?? throw new NullReferenceException("FactionRequestValidators is null");
       _responseValidator = responseValidator ?? throw new NullReferenceException("FactionResponseValidators is null");
    }
    
    public Faction CreateFaction(FactionRequest factionRequest)
    {
        if (factionRequest == null)
            throw new NullReferenceException("FactionRequest is null");
        
        var validation = _requestValidator.Validate(factionRequest);
        
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        
        var faction = _mapper.Map<Faction>(factionRequest);
        
        var createdFaction = _factionRepository.CreateFaction(faction);
        
        if (createdFaction == null)
            throw new NullReferenceException("Return Faction is null");
        
        var validatedFaction = _validator.Validate(createdFaction);
        
        if (!validatedFaction.IsValid)
            throw new ValidationException(validatedFaction.ToString());
        
        return createdFaction;
    }

    public List<Faction> GetAllFactions()
    {
        List<Faction> factionList = _factionRepository.GetAllFactions();
        
        if (factionList == null)
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
        
        var validatedFaction = _validator.Validate(faction);
        
        if (validatedFaction.IsValid)
            throw new ValidationException(validatedFaction.ToString());
        
        return faction;
    }

    public Faction UpdateFaction(Faction faction)
    {
        if (faction == null)
            throw new NullReferenceException("Faction is null");
        
        var validation = _validator.Validate(faction);
        
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        
        
        var updatedFaction = _factionRepository.UpdateFaction(faction);
        
        if (updatedFaction == null)
            throw new Exception("Faction could not be updated");
        
        var validatedFaction = _validator.Validate(updatedFaction);
        
        if (validatedFaction.IsValid)
            throw new ValidationException(validatedFaction.ToString());
        
        return updatedFaction;
        
    }

    public bool DeleteFaction(Faction faction)
    {
        if (faction == null)
            throw new NullReferenceException("Faction is null");
        
        var validation = _validator.Validate(faction);
        
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        
        var deletedFaction = _factionRepository.DeleteFaction(faction);
        
        if (!deletedFaction)
            throw new Exception("Faction could not be deleted");
        
        return true;
    }
}