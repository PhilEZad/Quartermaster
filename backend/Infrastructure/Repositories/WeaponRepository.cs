using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class WeaponRepository : IWeaponRepository
{
    private readonly DatabaseContext _context;

    public WeaponRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Weapon Create(Weapon weapon)
    {
        throw new NotImplementedException();
    }

    public List<Weapon> GetAllWeapons()
    {
        throw new NotImplementedException();
    }

    public Weapon GetWeaponById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Weapon> GetWeaponByFactionId(int id)
    {
        throw new NotImplementedException();
    }

    public Weapon Update(Weapon weapon)
    {
        throw new NotImplementedException();
    }

    public bool Delete(WeaponRequest weapon)
    {
        throw new NotImplementedException();
    }
}