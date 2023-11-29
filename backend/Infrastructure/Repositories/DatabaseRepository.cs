using Application.Interfaces;

namespace Infrastructure.Repositories;

public class DatabaseRepository : IDatabase
{
    private DatabaseContext _context;
    
    public DatabaseRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void BuildDb()
    {
        _context.Database.EnsureCreated();
        _context.Database.EnsureCreated();
    }
}