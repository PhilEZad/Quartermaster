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
        _context.Weapons.Add(weapon);
        _context.SaveChanges();

        return weapon;
    }

    public List<Weapon> GetAllWeapons()
    {
        return _context.Weapons.ToList();
    }

    public Weapon GetWeaponById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Weapon> GetWeaponsByModelId(int id)
    {
        throw new NotImplementedException();
    }

    public List<Weapon> GetWeaponsByFactionId(int id)
    {
        return _context.Weapons
            .Where(w => w.Faction.Id == id)
            .ToList();
    }

    public Weapon Update(Weapon weapon)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        var weapon = _context.Weapons.Find(id) ??
                      throw new Exception("Faction not found");
        _context.Weapons.Remove(weapon);
        var change =_context.SaveChanges();
        return change > 0;
    }
}