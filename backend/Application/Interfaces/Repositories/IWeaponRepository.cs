using Application.DTOs;
using Application.DTOs.Responses;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IWeaponRepository
{
    public Weapon Create(Weapon weapon);
    public List<Weapon> GetAllWeapons();
    public Weapon GetWeaponById(int id);
    public List<Weapon> GetWeaponByFactionId(int id);
    
    public Weapon Update(Weapon weapon);
    
    public Boolean Delete(WeaponRequest weapon);
}