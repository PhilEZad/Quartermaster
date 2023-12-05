using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Validators;
using AutoMapper;
using Domain;

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
        throw new NotImplementedException();
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