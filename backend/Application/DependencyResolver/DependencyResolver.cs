using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver;

public class DependencyResolver
{
    public static void RegisterApplicationLayer(IServiceCollection service)
    
    {
        // Automapper
        service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        // Validators
        service.AddScoped<UserValidator>();
        service.AddScoped<RegisterRequestValidator>();
        service.AddScoped<LoginRequestValidators>();
        service.AddScoped<LoginResponseValidators>();
        
        service.AddScoped<FactionValidator>();
        service.AddScoped<FactionRequestValidator>();
        service.AddScoped<FactionResponseValidator>();

        service.AddScoped<UnitValdiator>();
        service.AddScoped<UnitRequestValidator>();

        // Services
        service.AddScoped<IFactionService, FactionService>();
        service.AddScoped<IAuthenticationService, AuthenticationService>();
        service.AddScoped<IAccountService, AccountService>();
        service.AddScoped<IWeaponService, WeaponService>();
        service.AddScoped<IUnitService, UnitService>();
    }
}