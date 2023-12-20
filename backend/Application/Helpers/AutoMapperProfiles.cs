﻿using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.DTOs.Updates;
using AutoMapper;
using Domain;

namespace Application.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // Request to Model
        CreateMap<RegisterRequest, User>();
        CreateMap<FactionRequest, Faction>();
        CreateMap<UnitRequest, Unit>();
        CreateMap<AbilityRequest, Ability>();
        
        CreateMap<FactionUpdate, Faction>();
        
        CreateMap<WeaponRequest, Weapon>();
        CreateMap<WeaponUpdate, Weapon>();
        
        
        // Model to Response
        CreateMap<Faction, FactionResponse>();
        CreateMap<Unit, UnitResponse>();
        CreateMap<Weapon, WeaponResponse>();
        CreateMap<Ability, AbilityResponse>();
        
    }
}