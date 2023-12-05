using Application.DTOs;
using Application.DTOs.Responses;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IWeaponRepository
{
    public WeaponResponse Create(WeaponRequest weapon);
    
    public List<Weapon> GetAllWeapons();
    public Weapon GetWeaponById(int id);
    public List<Weapon> GetWeaponByModelId(int id);
    public List<Weapon> GetWeaponByFactionId(int id);
    
    public Weapon Update(Weapon weapon);
    
    public Boolean Delete(WeaponRequest weapon);
}