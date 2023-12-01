using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Authentication;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolver;

public class DependencyResolver
{
    public static void RegisterInfrastructureLayer(IServiceCollection service)
    {
        service.AddScoped<IJwtProvider, JwtProvider>();
        service.AddScoped<IPasswordHasher, PasswordHasher>();
        service.AddScoped<IDatabase, DatabaseRepository>();
        service.AddScoped<IAccountRepository, AccountRepository>();
    }
}