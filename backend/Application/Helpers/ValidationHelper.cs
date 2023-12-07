using Application.Helpers.Helper_Interfaces;
using FluentValidation;

namespace Application.Helpers;

public class ValidationHelper : IValidationHelper
{
    public void ValidateAndThrow<T>(AbstractValidator<T> validator, T objectToValidate)
    {
        if (objectToValidate == null)
        {
            throw new ArgumentException(nameof(objectToValidate) + " can not be null");
        }
        
        var validationResult = validator.Validate(objectToValidate);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }

}