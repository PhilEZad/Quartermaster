﻿using Application.DTOs;
using Application.DTOs.Responses;
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
        CreateMap<WeaponRequest, Weapon>();
        
        
        // Model to Response
        CreateMap<Faction, FactionResponse>();
        CreateMap<Unit, UnitResponse>();
        CreateMap<Weapon, WeaponResponse>();
    }
}