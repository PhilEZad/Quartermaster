using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class UnitRepository : IUnitRepository
{
    private readonly DatabaseContext _dbContext;

    public UnitRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Unit CreateUnit(Unit unit)
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