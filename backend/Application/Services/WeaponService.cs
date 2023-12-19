using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;

namespace Application.Services;

public class WeaponService : IWeaponService
{
    private readonly IWeaponRepository _weaponRepository;
    private readonly IMapper _mapper;
    private readonly IValidationHelper _validationHelper;

    public WeaponService(IWeaponRepository weaponRepository, IMapper mapper, IValidationHelper validationHelper)
    {
        _weaponRepository = weaponRepository ?? throw new NullReferenceException("WeaponRepository is null");
        _mapper = mapper ?? throw new NullReferenceException("Mapper is null");
        _validationHelper = validationHelper ?? throw new NullReferenceException("ValidationHelper is null");
    }

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