
using Application.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private DatabaseContext _context;
    
    public AccountRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public User Create(User user, string type)
    {
        if (_context.Users.Any(u => u.Username == user.Username))
            throw new Exception("User already exists");
        
        if (_context.Users.Any(u => u.Email == user.Email))
            throw new Exception("Email is already registered");
        
        var existingRole = _context.RolesTable.First(u => u.Name == type);

        if (existingRole == null)
        {
            throw new Exception("Role not found");
        }
        
        user.Roles = new List<Role> { existingRole };
        
        _context.Users.Add(user);
        
        _context.SaveChanges();

        return user;
    }

    public bool DoesUserExist(string username)
    {
        return _context.Users.Any(u => u.Username == username);
    }

    public User GetUserByUsername(string loginRequestUsername)
    {
        var returnUser = _context.Users.Include("Roles").FirstOrDefault(u => u.Username == loginRequestUsername);
        
        return returnUser;
    }
}