
using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private DatabaseContext _context;
    
    public AccountRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public User Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
}