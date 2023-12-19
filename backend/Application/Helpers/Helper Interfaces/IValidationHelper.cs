using FluentValidation;

namespace Application.Helpers.Helper_Interfaces;

public interface IValidationHelper
{
    public void ValidateOrThrow<T>(T objectToValidate);
}