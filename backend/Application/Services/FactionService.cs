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
    
    public Faction CreateFaction(Faction faction)
    {
        throw new NotImplementedException();
    }

    public List<Faction> GetAllFactions()
    {
        throw new NotImplementedException();
    }

    public Faction GetFactionById(int id)
    {
        throw new NotImplementedException();
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