using Application.DTOs;
using Application.DTOs.Responses;
using Application.DTOs.Updates;
using Application.Helpers;
using Application.Helpers.Helper_Interfaces;
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
    
    private readonly IValidationHelper _validationHelper;
    private readonly FactionValidator _validator;
    private readonly FactionRequestValidator _requestValidator;
    private readonly FactionResponseValidator _responseValidator;
    
    public FactionService(
       IFactionRepository factionRepository,
       IMapper mapper,
        
       IValidationHelper validationHelper,
       FactionValidator validator,
       FactionRequestValidator requestValidator,
       FactionResponseValidator responseValidator)
    {
       _factionRepository = factionRepository ?? throw new NullReferenceException("FactionRepository is null");
       _mapper = mapper ?? throw new NullReferenceException("Mapper is null");
        
       _validationHelper = validationHelper ?? throw new NullReferenceException("ValidationHelper is null");
       _validator = validator ?? throw new NullReferenceException("FactionValidators is null");
       _requestValidator = requestValidator ?? throw new NullReferenceException("FactionRequestValidators is null");
       _responseValidator = responseValidator ?? throw new NullReferenceException("FactionResponseValidators is null");
    }
    
    public FactionResponse CreateFaction(DTOs.Requests.FactionRequest factionRequest)
    {
        _validationHelper.ValidateAndThrow(_requestValidator, factionRequest);
        var faction = _mapper.Map<Faction>(factionRequest);
        
        var createdFaction = _factionRepository.CreateFaction(faction);
        _validationHelper.ValidateAndThrow(_validator, createdFaction);
        
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
            throw new Exception("Id is invalid");
        
        Faction faction = _factionRepository.GetFactionById(id);
        
        _validationHelper.ValidateAndThrow(_validator, faction);

        FactionResponse response = _mapper.Map<FactionResponse>(faction);

        return response;
    }

    public FactionResponse UpdateFaction(FactionUpdate faction)
    {
        throw new NotImplementedException();
    }

    public bool DeleteFaction(int id)
    {
        return _factionRepository.DeleteFaction(id);
    }
}