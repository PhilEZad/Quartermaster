using Application.DTOs.Responses;
using Application.Helpers;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.Validators;
using Application.Validators.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver;

public class DependencyResolver
{
    public static void RegisterApplicationLayer(IServiceCollection service)
    
    {
        // Automapper
        service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        // Validators
        service.AddScoped<IValidatorFactory, ValidatorFactory>();
        
        service.AddScoped<UserValidator>();
        service.AddScoped<RegisterRequestValidator>();
        service.AddScoped<LoginRequestValidators>();
        service.AddScoped<LoginResponseValidators>();
        
        service.AddScoped<FactionValidator>();
        service.AddScoped<FactionRequestValidator>();
        service.AddScoped<FactionResponseValidator>();
        service.AddScoped<FactionUpdateValidator>();

        service.AddScoped<UnitValidator>();
        service.AddScoped<UnitRequestValidator>();
        
        service.AddScoped<WeaponValidator>();
        service.AddScoped<WeaponRequestValidator>();
        service.AddScoped<WeaponResponse>();
        
        service.AddScoped<AbilityValidator>();
        service.AddScoped<AbilityRequestValidator>();
        service.AddScoped<AbilityResponseValidator>();

        // Services
        service.AddScoped<IFactionService, FactionService>();
        service.AddScoped<IAuthenticationService, AuthenticationService>();
        service.AddScoped<IAccountService, AccountService>();
        service.AddScoped<IWeaponService, WeaponService>();
        service.AddScoped<IUnitService, UnitService>();
        service.AddScoped<IAbilityService, AbilityService>();
        
        // Helpers
        service.AddScoped<IValidationHelper, ValidationHelper>();
    }
}