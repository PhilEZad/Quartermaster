using Domain;

namespace Application.Interfaces.Repositories;

public interface IRoleRepository
{
    public Role GetRoleByName(string roleName);
}