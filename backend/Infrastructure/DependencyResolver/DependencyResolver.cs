using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolver;

public class DependencyResolver
{
    public static void RegisterInfrastructureLayer(IServiceCollection service)
    {
        service.AddScoped<IDatabase, DatabaseRepository>();
        service.AddScoped<IAccountRepository, AccountRepository>();
    }
}