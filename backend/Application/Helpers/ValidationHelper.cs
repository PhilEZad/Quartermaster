using Application.Helpers.Helper_Interfaces;
using FluentValidation;
using IValidatorFactory = Application.Validators.Factory.IValidatorFactory;

namespace Application.Helpers;

public class ValidationHelper : IValidationHelper
{
    private readonly IValidatorFactory _validatorFactory;

    public ValidationHelper(IValidatorFactory validatorFactory)
    {
        _validatorFactory = validatorFactory;
    }

    public void ValidateOrThrow<T>(T objectToValidate)
    {
        if (objectToValidate == null)
        {
            throw new ArgumentException("Object to validate cannot be null");
        }
        
        var validator = _validatorFactory.GetValidator<T>();
        var validationResult = validator.Validate(objectToValidate);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToString());
        }
    }

}