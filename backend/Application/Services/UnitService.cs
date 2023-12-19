using Application.DTOs.Requests;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain;

namespace Application.Services;

public class UnitService : IUnitService
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;
    private readonly IValidationHelper _validationHelper;
    
    

    public UnitService(IUnitRepository unitRepository, IMapper mapper, IValidationHelper validationHelper)
    {
        _unitRepository = unitRepository ?? throw new NullReferenceException("UnitRepository is null");
        _mapper = mapper ?? throw new NullReferenceException("Mapper is null");
        _validationHelper = validationHelper ?? throw new NullReferenceException("ValidationHelper is null");
    }

    public Unit CreateUnit(UnitRequest unitRequest)
    {
        if (unitRequest == null)
        {
            throw new NullReferenceException("UnitRequest is null");
        }

        _validationHelper.ValidateOrThrow(unitRequest);
        
        var unit = _mapper.Map<Unit>(unitRequest);
        
        var repoUnit = _unitRepository.CreateUnit(unit);
        
        var returnUnit = _mapper.Map<Unit>(repoUnit);
        
        _validationHelper.ValidateOrThrow(returnUnit);
        
        return returnUnit;
    }

    public List<Unit> GetAllUnits()
    {
        throw new NotImplementedException();
    }

    public Unit GetUnitById(int id)
    {
        throw new NotImplementedException();
    }

    public Unit UpdateUnit(Unit unit)
    {
        throw new NotImplementedException();
    }

    public bool DeleteUnit(Unit unit)
    {
        throw new NotImplementedException();
    }
}