using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Application.Validators;
using FluentAssertions;
using FluentValidation;
using Moq;

namespace UnitTests.Services;


public class AccountTests
{
    [Fact]
    public void CreateService_WithNullRepository_ShouldThrowNullReferenceException()
    {
        var repo = new Mock<IAccountRepository>();
        var validator = null as UserValidator;
        var validatorDto = new UserDTOValidator();
        Action test = () => new AccountService(null, validator, validatorDto);

        test.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void CreateService_WithValidRepository_ShouldNotThrowNullReferenceException()
    {
        var repo = new Mock<IAccountRepository>();
        var validator = null as UserValidator;
        var validatorDto = new UserDTOValidator();
        Action test = () => new AccountService(repo.Object, validator, validatorDto);

        test.Should().NotThrow<NullReferenceException>();
    }
    
    [Fact]
    public void CreateService_WithNullValidator_ShouldThrowNullReferenceException()
    {
        var repo = new Mock<IAccountRepository>();
        var validator = null as UserValidator;
        var validatorDto = new UserDTOValidator();
        
        Action test = () => new AccountService(repo.Object, validator, validatorDto);

        test.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void CreateService_WithNullValidatorDTO_ShouldThrowNullReferenceException()
    {
        var repo = new Mock<IAccountRepository>();
        var validator = new UserValidator();
        var validatorDto = null as UserDTOValidator;
        
        Action test = () => new AccountService(repo.Object, validator, null);

        test.Should().Throw<NullReferenceException>();
    }
    [Fact]
    public void CreateService_WithValidValidators_ShouldNotThrowNullReferenceException()
    {
        var repo = new Mock<IAccountRepository>();
        var validator = new UserValidator();
        var validatorDto = new UserDTOValidator();

        Action test = () => new AccountService(repo.Object, validator, validatorDto);

        test.Should().NotThrow<NullReferenceException>();
    }
    /*
     * Account Creation Tests
     */
    
    [Fact]
    public void CreateAccount_WithNull_ShouldThrowNullReferenceException()
    {
        var repo = new Mock<IAccountRepository>();
        var validator = new UserValidator();
        var validatorDto = new UserDTOValidator();
        AccountService service = new(repo.Object, validator, validatorDto);
        
        Action test = () => service.Create(null);

        test.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void CreateAccount_WithValidObject_ShouldNotThrowNullReferenceException()
    {
        var repo = new Mock<IAccountRepository>();
        var validator = new UserValidator();
        var validatorDto = new UserDTOValidator();
        AccountService service = new(repo.Object, validator, validatorDto);

        var user = new UserDTO
        {
            username = "test",
            password = "test",
        };
        
        Action test = () => service.Create(user);

        test.Should().NotThrow<NullReferenceException>();
    }
    
    [Fact]
    public void CreateAccount_Success_ShouldReturnTrue()
    {
        var repo = new Mock<IAccountRepository>();
        var validator = new UserValidator();
        var validatorDto = new UserDTOValidator();
        AccountService service = new(repo.Object, validator, validatorDto);

        var user = new UserDTO
        {
            username = "test",
            password = "test",
        };
        
        Action result = () => service.Create(user);

        result.Should().NotThrow<Exception>();
    }
    
    [Fact]
    public void CreateAccount_Failure_ShouldReturnFalse()
    {
        var repo = new Mock<IAccountRepository>();
        var validator = new UserValidator();
        var validatorDto = new UserDTOValidator();
        AccountService service = new(repo.Object, validator, validatorDto);

        var user = new UserDTO
        {
            username = "test",
            password = "test",
        };

        Action result = () => service.Create(user);

        result.Should().Throw<Exception>().WithMessage("Failed to create account");
    }
    
    [Fact]
    public void CreateAccount_WithExistingUser_ShouldReturnMessage()
    {
        var repo = new Mock<IAccountRepository>();
        var validator = null as UserValidator;
        var validatorDto = new UserDTOValidator();
        AccountService service = new(repo.Object, validator, validatorDto);

        var user = new UserDTO
        {
            username = "test",
            password = "test",
        };
        
        Action result = () => service.Create(user);

        result.Should().Throw<Exception>().WithMessage("User already exists");
    }
    
    [Theory]
    [InlineData("1234","Password must be at least 8 characters long")]
    [InlineData("","Password must be at least 8 characters long")]
    public void CreateAccount_WithInvalidPassword_ShouldReturnMessage(String password, String errorMessage)
    {
        var repo = new Mock<IAccountRepository>();
        var validator = null as UserValidator;
        var validatorDto = new UserDTOValidator();
        AccountService service = new(repo.Object, validator, validatorDto);

        var user = new UserDTO()
        {
            username = "test",
            password = password,
        };
        
        Action result = () => service.Create(user);

        result.Should().Throw<ValidationException>().WithMessage(errorMessage);
    }
    
    [Fact]
    public void CreateAccount_WithValidPassword_ShouldNotThrowException()
    {
        var repo = new Mock<IAccountRepository>();
        var validator = null as UserValidator;
        var validatorDto = new UserDTOValidator();
        AccountService service = new(repo.Object, validator, validatorDto);

        var user = new UserDTO()
        {
            username = "test",
            password = "thisisavalidpassword",
        };
        
        Action result = () => service.Create(user);

        result.Should().NotThrow<ValidationException>();
    }
    
    /*
     * Account Login Tests
     */
}