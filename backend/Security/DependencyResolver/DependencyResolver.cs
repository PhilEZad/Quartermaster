using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Security.Authentication;

namespace Security.DependencyResolver;

public class DependencyResolver
{
    public static void RegisterSecurityLayer(IServiceCollection service)
    {
        service.AddScoped<IJwtProvider, JwtProvider>();
        service.AddScoped<IPasswordHasher, PasswordHasher>();
    }
}