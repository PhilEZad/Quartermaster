using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces.Services;

namespace Application.Services;

public class WeaponService : IWeaponService
{
    public WeaponResponse CreateWeapon(WeaponRequest weaponRequest)
    {
        throw new NotImplementedException();
    }

    public List<WeaponResponse> GetAllWeapons()
    {
        throw new NotImplementedException();
    }

    public WeaponResponse GetWeaponById(int id)
    {
        throw new NotImplementedException();
    }

    public List<WeaponResponse> GetWeaponByModelId(int id)
    {
        throw new NotImplementedException();
    }

    public List<WeaponResponse> GetWeaponByFactionId(int id)
    {
        throw new NotImplementedException();
    }

    public WeaponResponse UpdateWeapon(WeaponRequest weaponRequest)
    {
        throw new NotImplementedException();
    }

    public bool DeleteWeapon(WeaponRequest weaponRequest)
    {
        throw new NotImplementedException();
    }
}