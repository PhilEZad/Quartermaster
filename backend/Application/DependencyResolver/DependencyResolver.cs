﻿using Application.Interfaces.Repositories;
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
        service.AddScoped<RegisterRequestValidator>();
        service.AddScoped<LoginRequestValidators>();
        service.AddScoped<LoginResponseValidators>();

        service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        service.AddScoped<IFactionService, FactionService>();
        service.AddScoped<IAuthenticationService, AuthenticationService>();
        service.AddScoped<IAccountService, AccountService>();
    }
}