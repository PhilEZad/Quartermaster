using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.DTOs.Updates;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain;
using FluentValidation;

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
        if (weaponRequest == null)
            throw new NullReferenceException("WeaponRequest is null");
        
        _validationHelper.ValidateOrThrow(weaponRequest);
        
        var weapon = _mapper.Map<Weapon>(weaponRequest);
        
        var createdWeapon = _weaponRepository.Create(weapon);
        
        if (createdWeapon == null)
            throw new NullReferenceException("Return Weapon is null");
        
        _validationHelper.ValidateOrThrow(createdWeapon);
        
        WeaponResponse response = _mapper.Map<WeaponResponse>(createdWeapon);
        
        return response;
    }

    public List<WeaponResponse> GetAllWeapons()
    {
        var weapons = _weaponRepository.GetAllWeapons();
        
        if (weapons == null)
            throw new NullReferenceException("Weapons list is null");
        
        _validationHelper.ValidateOrThrow(weapons);
        
        List<WeaponResponse> response = _mapper.Map<List<WeaponResponse>>(weapons);
        
        return response;
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
        if (id <= 0)
            throw new ValidationException("Invalid ID");
        
        var weapons = _weaponRepository.GetWeaponsByFactionId(id);
        
        if (weapons == null)
            throw new NullReferenceException("Weapons list is null");
        
        _validationHelper.ValidateOrThrow(weapons);
        
        List<WeaponResponse> response = _mapper.Map<List<WeaponResponse>>(weapons);
        
        return response;
    }

    public WeaponResponse UpdateWeapon(WeaponUpdate weaponUpdate)
    {
        if (weaponUpdate == null)
            throw new NullReferenceException("WeaponUpdate is null");
        
        _validationHelper.ValidateOrThrow(weaponUpdate);
        
        var weapon = _mapper.Map<Weapon>(weaponUpdate);
        
        var updatedWeapon = _weaponRepository.Update(weapon);
        
        if (updatedWeapon == null)
            throw new NullReferenceException("Return Weapon is null");
        
        _validationHelper.ValidateOrThrow(updatedWeapon);
        
        WeaponResponse response = _mapper.Map<WeaponResponse>(updatedWeapon);
        
        return response;
    }

    public bool DeleteWeapon(WeaponRequest weaponRequest)
    {
        throw new NotImplementedException();
    }

    public bool DeleteWeapon(int id)
    {
        if (id <= 0)
            throw new ValidationException("Invalid ID");
        
        return _weaponRepository.Delete(id);
    }
}