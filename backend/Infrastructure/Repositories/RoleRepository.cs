using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly DatabaseContext _context;

    public RoleRepository(DatabaseContext context)
    {
        _context = context;
    }


    public Role GetRoleByName(string roleName)
    {
        return _context.RolesTable.FirstOrDefault(role => role.Name == roleName) ??
               throw new KeyNotFoundException("No role with the name " + roleName + " was found");
    }
}