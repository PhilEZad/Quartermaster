using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Interfaces.Services;

public interface IWeaponService
{
    public WeaponResponse CreateWeapon(WeaponRequest weaponRequest);
    
    public List<WeaponResponse> GetAllWeapons();
    public WeaponResponse GetWeaponById(int id);
    public List<WeaponResponse> GetWeaponByModelId(int id);
    public List<WeaponResponse> GetWeaponByFactionId(int id);
    
    public WeaponResponse UpdateWeapon(WeaponRequest weaponRequest);
    
    public Boolean DeleteWeapon(int id);
}