using Application.Interfaces;
using Application.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class DatabaseRepository : IDatabase
{
    private readonly DatabaseContext _context;
    
    public DatabaseRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void BuildDb()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
}