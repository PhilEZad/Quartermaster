using Application.DTOs;
using Domain;

namespace Application.Interfaces.Services;

public interface IUnitService
{
    public Unit CreateUnit(UnitRequest unitRequest);
    public List<Unit> GetAllUnits();
    public Unit GetUnitById(int id);
    public Unit UpdateUnit(Unit unit);
    public Boolean DeleteUnit(Unit unit);
}