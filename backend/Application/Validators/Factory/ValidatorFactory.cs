﻿using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Domain;
using FluentValidation;
namespace Application.Validators.Factory;

public class ValidatorFactory : IValidatorFactory
{
    public AbstractValidator<T> GetValidator<T>()
    {
        switch (true)
        {
            // Faction Validators
            case bool _ when typeof(T) == typeof(Faction):
                return (AbstractValidator<T>)(object)new FactionValidator();
            case bool _ when typeof(T) == typeof(FactionRequest):
                return (AbstractValidator<T>)(object)new FactionRequestValidator();
            case bool _ when typeof(T) == typeof(FactionResponse):
                return (AbstractValidator<T>) (object) new FactionResponseValidator();
            
            // Authentication Validators
            case bool _ when typeof(T) == typeof(LoginRequest):
                return (AbstractValidator<T>)(object)new LoginRequestValidators();
            case bool _ when typeof(T) == typeof(LoginResponse):
                return (AbstractValidator<T>)(object)new LoginResponseValidators();
            
            // Register Validators
            case bool _ when typeof(T) == typeof(RegisterRequest):
                return (AbstractValidator<T>)(object)new RegisterRequestValidator();

            // User Validators
            case bool _ when typeof(T) == typeof(User):
                return (AbstractValidator<T>)(object)new UserValidator();
            
            // Unit Validators
            case bool _ when typeof(T) == typeof(Unit):
                return (AbstractValidator<T>)(object)new UnitValidator();
            case bool _ when typeof(T) == typeof(UnitRequest):
                return (AbstractValidator<T>)(object)new UnitRequestValidator();
            case bool _ when typeof(T) == typeof(UnitResponse):
                return (AbstractValidator<T>)(object)new UnitResponseValidator();
            
            // Weapon Validators
            case bool _ when typeof(T) == typeof(Weapon):
                return (AbstractValidator<T>)(object)new WeaponValidator();
            case bool _ when typeof(T) == typeof(WeaponRequest):
                return (AbstractValidator<T>)(object)new WeaponRequestValidator();
            case bool _ when typeof(T) == typeof(WeaponResponse):
                return (AbstractValidator<T>)(object)new WeaponResponseValidator();
            
            // Ability Validators
            case bool _ when typeof(T) == typeof(Ability):
                return (AbstractValidator<T>)(object)new AbilityValidator();
            case bool _ when typeof(T) == typeof(AbilityRequest):
                return (AbstractValidator<T>)(object)new AbilityRequestValidator();
            case bool _ when typeof(T) == typeof(AbilityResponse):
                return (AbstractValidator<T>)(object)new AbilityResponseValidator();
            
            default:
                throw new ArgumentException($"No validator exists for type {typeof(T).Name}");
        }
    }
}