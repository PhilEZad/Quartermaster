﻿using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IWeaponRepository
{
    public Weapon Create(Weapon weapon);
    public List<Weapon> GetAllWeapons();
    public Weapon GetWeaponById(int id);
    
    public List<Weapon> GetWeaponsByModelId(int id);
    public List<Weapon> GetWeaponsByFactionId(int id);
    
    public Weapon Update(Weapon weapon);
    
    public Boolean Delete(int id);
}