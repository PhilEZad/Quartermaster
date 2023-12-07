using Application.DTOs;
using Application.DTOs.Requests;
using Application.Helpers;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Services;
using Application.Validators;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using Moq;
using Security;
using Security.Authentication;

namespace UnitTests.Services;

public class AuthenticationTests
{
    // Service Creation Tests
    [Fact]
    public void CreateService_WithNullAccountRepository_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithAccountRepository(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("AccountRepository is null");
    }
    
    [Fact]
    public void CreateService_WithNullMapper_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithMapper(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("Mapper is null");
    }
    
    [Fact]
    public void CreateService_WithNullLoginRequestValidator_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithLoginRequestValidator(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("LoginRequestValidator is null");
    }
    
    [Fact]
    public void CreateService_WithNullJwtProvider_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithJwtProvider(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("JwtProvider is null");
    }
    
    [Fact]
    public void CreateService_WithNullPasswordHasher_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithPasswordHasher(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("PasswordHasher is null");
    }
    
    [Fact]
    public void CreateService_WithNullLoginResponseValidator_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithLoginResponseValidator(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("LoginResponseValidator is null");
    }
    
    [Fact]
    public void CreateService_WithNullUserValidator_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithUserValidator(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("UserValidator is null");
    }
    
    [Fact]
    public void CreateService_WithValidParameters_ShouldNotThrowNullReferenceException()
    {
        //Arrange
        var setup = CreateServiceSetup();
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().NotThrow<NullReferenceException>();
    }
    
    // Login Tests
    
    [Fact]
    public void Login_WithNullLoginRequest_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        //Act
        Action test = () => service.Login(null);
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("Login Request is null");
    }
    
    [Theory]
    [InlineData("", "Username can not be empty")]
    [InlineData("abc", "Username must be at least 3 characters long")]
    [InlineData("thisusernameismorethan20characterslong", "Username may not more 20 characters")]
    [InlineData("Мойдомашнийпитомец", "Username must only contain alphanumeric characters, and can not contain spaces")]
    [InlineData("space space space", "Username must only contain alphanumeric characters, and can not contain spaces")]
    public void Login_WithInvalidUsername_ShouldThrowValidationExceptionWithMessage(string username, string message)
    {
        //Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        //Act
        Action test = () => service.Login(new LoginRequest
        {
            Username = username,
            Password = "12345678"
        });
        
        //Assert
        test.Should().Throw<ValidationException>().WithMessage(message);
    }
    
    /*
     * Helper Class /w methods for Tests Setup
     */
    private ServiceSetup CreateServiceSetup()
    {
        var repoMock = new Mock<IAccountRepository>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();
        var jwtOptions = Options.Create(new JwtOptions{
            Issuer = "Test Issuer",
            Audience = "Test Audience",
            Secret = "Test Secret",
            TokenExpirationInHours = 50
        });

        var jwtProvider = new JwtProvider(jwtOptions);
        var passwordHasher = new PasswordHasher();
        
        IValidationHelper validationHelper = new ValidationHelper();
        var loginRequestValidators = new LoginRequestValidators();
        var loginResponseValidators = new LoginResponseValidators();
        var userValidator = new UserValidator();

        return new ServiceSetup(repoMock, mapper, jwtProvider, passwordHasher, validationHelper, loginRequestValidators, loginResponseValidators, userValidator);
    }
    
    private class ServiceSetup
    {
        private IAccountRepository _accountRepository;
        private IMapper _mapper;
        private IJwtProvider _jwtProvider;
        private IPasswordHasher _passwordHasher;
        
        private IValidationHelper _validatorHelper;
        private LoginRequestValidators _loginRequestValidator;
        private LoginResponseValidators _loginResponseValidator;
        private UserValidator _userValidator;

        public ServiceSetup(
            Mock<IAccountRepository> repositoryMock,
            IMapper mapper,
            IJwtProvider jwtProvider,
            IPasswordHasher passwordHasher,
            
            IValidationHelper validatorHelper,
            LoginRequestValidators loginRequestValidators,
            LoginResponseValidators loginResponseValidators,
            UserValidator userValidator
        )
        {
            _accountRepository = repositoryMock.Object;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
            _validatorHelper = validatorHelper;

            _userValidator = userValidator;
            _loginRequestValidator = loginRequestValidators;
            _loginResponseValidator = loginResponseValidators;
        }

        public ServiceSetup WithAccountRepository(IAccountRepository repositoryMock)
        {
            _accountRepository = repositoryMock;
            return this;
        }

        public ServiceSetup WithMapper(IMapper mapper)
        {
            _mapper = mapper;
            return this;
        }
        
        public ServiceSetup WithJwtProvider(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
            return this;
        }
        
        public ServiceSetup WithPasswordHasher(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            return this;
        }
        
        public ServiceSetup WithLoginRequestValidator(LoginRequestValidators loginRequestValidators)
        {
            _loginRequestValidator = loginRequestValidators;
            return this;
        }
        
        public ServiceSetup WithLoginResponseValidator(LoginResponseValidators loginResponseValidators)
        {
            _loginResponseValidator = loginResponseValidators;
            return this;
        }
        
        public ServiceSetup WithUserValidator(UserValidator userValidator)
        {
            _userValidator = userValidator;
            return this;
        }

        public AuthenticationService CreateService()
        {
            return new AuthenticationService(
                _accountRepository,
                _mapper,
                _jwtProvider,
                _passwordHasher,
                _validatorHelper,
                _loginRequestValidator,
                _loginResponseValidator,
                _userValidator
            );
        }
    }
}