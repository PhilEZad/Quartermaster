
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
        
        return user;
    }

    public bool DoesUserExist(string username)
    {
        return _context.Users.Any(u => u.Username == username);
    }

    public User GetUserByUsername(string loginRequestUsername)
    {
        var returnUser = _context.Users.FirstOrDefault(u => u.Username == loginRequestUsername);
        
        return returnUser;
    }
}