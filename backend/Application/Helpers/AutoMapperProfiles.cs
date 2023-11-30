using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<RegisterRequest, User>();
    }
}