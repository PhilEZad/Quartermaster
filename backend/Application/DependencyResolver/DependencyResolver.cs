using Application.Interfaces.Services;
using Application.Services;
using Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver;

public class DependencyResolver
{
    public static void RegisterApplicationLayer(IServiceCollection service)
    
    {
        service.AddScoped<UserValidator>();
        service.AddScoped<CreateAccountValidator>();
        service.AddScoped<IAccountService, AccountService>();
    }
}