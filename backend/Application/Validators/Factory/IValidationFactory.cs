namespace Application.Validators;

public interface IValidationFactory
{
    TValidator CreateValidator<TValidator>() where TValidator : class;
}