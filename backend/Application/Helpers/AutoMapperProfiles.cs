using Application.DTOs;
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
        CreateMap<DTOs.Requests.FactionRequest, Faction>();
        CreateMap<UnitRequest, Unit>();
        CreateMap<WeaponRequest, Weapon>();
        CreateMap<AbilityRequest, Ability>();
        
        
        // Model to Response
        CreateMap<Faction, FactionResponse>();
        CreateMap<Unit, UnitResponse>();
        CreateMap<Weapon, WeaponResponse>();
        CreateMap<Ability, AbilityResponse>();
    }
}