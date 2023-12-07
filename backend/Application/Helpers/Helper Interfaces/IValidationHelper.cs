using FluentValidation;

namespace Application.Helpers.Helper_Interfaces;

public interface IValidationHelper
{
    public void ValidateAndThrow<T>(AbstractValidator<T> validator, T objectToValidate);
}