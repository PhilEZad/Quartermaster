using Domain;

namespace Application.Interfaces.Repositories;

public interface IUnitRepository
{
    public Unit CreateUnit(Unit unit);
    public List<Unit> GetAllUnits();
    public Unit GetUnitById(int id);
    public Unit UpdateUnit(Unit unit);
    public Boolean DeleteUnit(Unit unit);
}