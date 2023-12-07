namespace Application.Validators;

public class ValidatorFactory : IValidationFactory
{
    public TValidator CreateValidator<TValidator>() where TValidator : class
    {
        throw new NotImplementedException();
    }
}