using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Services;
using Application.Validators;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Infrastructure;
using Moq;

namespace UnitTests.Services;


public class AccountTests
{
    private IAccountRepository _repo;
    private UserValidator _userValidator;
    private RegisterRequestValidator _registerRequestValidator;
    private PasswordHasher _passwordHasher;
    private IMapper _mapper;
    private Mock<IAccountRepository> repo;

    public AccountTests(IAccountRepository repo, UserValidator userValidator, RegisterRequestValidator registerRequestValidator, PasswordHasher passwordHasher, IMapper mapper)
    {
        _repo = repo;
        _userValidator = userValidator;
        _registerRequestValidator = registerRequestValidator;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
        this.repo = new Mock<IAccountRepository>();
    }

    [Fact]
    public void CreateService_WithNullRepository_ShouldThrowNullReferenceException()
    {
        Action test = () => new AccountService(null, _passwordHasher, _mapper, _userValidator, _registerRequestValidator);

        test.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void CreateService_WithValidRepository_ShouldNotThrowNullReferenceException()
    {
        Action test = () => new AccountService(repo.Object, _passwordHasher, _mapper, _userValidator, _registerRequestValidator);

        test.Should().NotThrow<NullReferenceException>();
    }
    
    [Fact]
    public void CreateService_WithNullValidator_ShouldThrowNullReferenceException()
    {
        Action test = () => new AccountService(repo.Object, _passwordHasher, _mapper, _userValidator, _registerRequestValidator);

        test.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void CreateService_WithNullValidatorDTO_ShouldThrowNullReferenceException()
    {
        Action test = () => new AccountService(repo.Object, _passwordHasher, _mapper, _userValidator, null);

        test.Should().Throw<NullReferenceException>();
    }
    [Fact]
    public void CreateService_WithValidValidators_ShouldNotThrowNullReferenceException()
    {
        Action test = () => new AccountService(repo.Object, _passwordHasher, _mapper, _userValidator, _registerRequestValidator);

        test.Should().NotThrow<NullReferenceException>();
    }
    /*
     * Account Creation Tests
     */
    
    [Fact]
    public void CreateAccount_WithNull_ShouldThrowNullReferenceException()
    {
        var service = new AccountService(repo.Object, _passwordHasher, _mapper, _userValidator, _registerRequestValidator);
        
        Action test = () => service.Create(null);

        test.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void CreateAccount_WithValidObject_ShouldNotThrowNullReferenceException()
    {
        var service = new AccountService(repo.Object, _passwordHasher, _mapper, _userValidator, _registerRequestValidator);

        var user = new RegisterRequest
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
        var service = new AccountService(repo.Object, _passwordHasher, _mapper, _userValidator, _registerRequestValidator);

        var user = new RegisterRequest
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
        var service = new AccountService(repo.Object, _passwordHasher, _mapper, _userValidator, _registerRequestValidator);

        var user = new RegisterRequest
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
        var service = new AccountService(repo.Object, _passwordHasher, _mapper, _userValidator, _registerRequestValidator);

        var user = new RegisterRequest
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
        var service = new AccountService(repo.Object, _passwordHasher, _mapper, _userValidator, _registerRequestValidator);

        var user = new RegisterRequest()
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
        var service = new AccountService(repo.Object, _passwordHasher, _mapper, _userValidator, _registerRequestValidator);

        var user = new RegisterRequest()
        {
            username = "test",
            password = "thisisavalidpassword",
        };
        
        Action result = () => service.Create(user);

        result.Should().NotThrow<ValidationException>();
    }
}