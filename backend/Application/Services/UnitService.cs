using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application.Services;

public class UnitService : IUnitService
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;
    
    private readonly UnitValdiator _unitValidator;
    private readonly UnitRequestValidator _unitRequestValidator;

    public UnitService(IUnitRepository unitRepository, IMapper mapper, UnitValdiator unitValidator, UnitRequestValidator unitRequestValidator)
    {
        _unitRepository = unitRepository ?? throw new NullReferenceException("UnitRepository is null");
        _mapper = mapper ?? throw new NullReferenceException("Mapper is null");
        _unitValidator = unitValidator ?? throw new NullReferenceException("UnitValidator is null");
        _unitRequestValidator = unitRequestValidator ?? throw new NullReferenceException("UnitRequestValidator is null");
    }

    public Unit CreateUnit(UnitRequest unitRequest)
    {
        if (unitRequest == null)
        {
            throw new NullReferenceException("UnitRequest is null");
        }
        
        var validationResult = _unitRequestValidator.Validate(unitRequest);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var unit = _mapper.Map<Unit>(unitRequest);
        
        var repoUnit = _unitRepository.CreateUnit(unit);
        
        var returnUnit = _mapper.Map<Unit>(repoUnit);
        
        var validationUnitResult = _unitValidator.Validate(returnUnit);
        
        if (!validationUnitResult.IsValid)
        {
            throw new ValidationException(validationUnitResult.Errors);
        }
        
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