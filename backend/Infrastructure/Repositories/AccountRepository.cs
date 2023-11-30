
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
        int change = _context.SaveChanges();
        
        if (change > 0)
            return user;
        else
            throw new Exception("User not created");
    }

    public bool DoesUserExist(string username)
    {
        return _context.Users.Any(u => u.Username == username);
    }
}