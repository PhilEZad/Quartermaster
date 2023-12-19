using FluentValidation;

namespace Application.Validators.Factory;

public interface IValidatorFactory
{
    AbstractValidator<T> GetValidator<T>();
}