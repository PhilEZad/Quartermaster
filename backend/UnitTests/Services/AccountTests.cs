using Application.DTOs;
using Application.Helpers;
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
    [Fact]
    public void CreateService_WithValidInjections_ShouldNotThrowNullReferenceException()
    {
        // Arrange
        var setup = CreateServiceSetup();

        // Act
        Action test = () => setup.CreateService();

        // Assert
        test.Should().NotThrow<NullReferenceException>();
    }
    
    [Fact]
    public void CreateService_WithNullRepository_ShouldThrowNullReferenceException()
    {
        // Arrange
        var setup = CreateServiceSetup()
            .WithAccountRepository(null);

        // Act
        Action test = () => setup.CreateService();

        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("AccountRepository is null");
    }

    [Fact]
    public void CreateService_WithNullValidator_ShouldThrowNullReferenceException()
    {
        // Arrange
        var setup = CreateServiceSetup()
            .WithUserValidator(null);

        // Act
        Action test = () => setup.CreateService();

        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("UserValidator is null");
    }
    
    [Fact]
    public void CreateService_WithNullValidatorDTO_ShouldThrowNullReferenceException()
    {
        // Arrange
        var setup = CreateServiceSetup()
            .WithRegisterRequestDto(null);

        // Act
        Action test = () => setup.CreateService();

        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("RegisterRequestDtoValidator is null");
    }
    
    [Fact]
    public void CreateService_WithNullHasher_ShouldThrowNullReferenceException()
    {
        // Arrange
        var setup = CreateServiceSetup()
            .WithPasswordHasher(null);

        // Act
        Action test = () => setup.CreateService();

        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("PasswordHasher is null");
    }
    
    [Fact]
    public void CreateService_WithNullMapper_ShouldThrowNullReferenceException()
    {
        // Arrange
        var setup = CreateServiceSetup()
            .WithMapper(null);

        // Act
        Action test = () => setup.CreateService();

        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("Mapper is null");
    }

    /*
     * Account Creation Tests
     */
    
    [Fact]
    public void CreateAccount_WithNull_ShouldThrowNullReferenceException()
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        // Act
        Action test = () => service.Create(null);

        // Assert
        test.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void CreateAccount_WithValidObject_ShouldNotThrowNullReferenceException()
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        var user = new RegisterRequest
        {
            username = "test",
            email = "thisisavalid@email.com",
            password = "test1231412312",
        };
        
        // Act
        Action test = () => service.Create(user);

        // Assert
        test.Should().NotThrow<NullReferenceException>();
    }
    
    [Fact]
    public void CreateAccount_Success_ShouldReturnTrue()
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        var user = new RegisterRequest
        {
            username = "test",
            email = "thisisavalid@email.com",
            password = "test12312412312312",
        };
        
        // Act
        Action result = () => service.Create(user);

        // Assert
        result.Should().NotThrow<Exception>();
    }
    
    [Fact]
    public void CreateAccount_Failure_ShouldReturnFalse()
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        var user = new RegisterRequest
        {
            username = "test",
            email = "thisisavalid@email.com",
            password = "test13214123123123",
            
        };

        // Act
        Action result = () => service.Create(user);

        // Assert
        result.Should().Throw<Exception>().WithMessage("Failed to create account");
    }
    
    [Fact]
    public void CreateAccount_WithExistingUser_ShouldReturnMessage()
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        var user = new RegisterRequest
        {
            username = "test",
            email = "thisisavalid@email.com",
            password = "test1234123",
        };
        
        // Act
        Action result = () => service.Create(user);

        // Assert
        result.Should().Throw<Exception>().WithMessage("User already exists");
    }
    
    [Theory]
    [InlineData("1234","Password must be at least 8 characters long")]
    [InlineData("","Password can not be empty")]
    public void CreateAccount_WithInvalidPassword_ShouldReturnMessage(String password, String errorMessage)
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        var user = new RegisterRequest()
        {
            username = "test",
            email = "thisisavalid@email.com",
            password = password,
        };
        
        // Act
        Action result = () => service.Create(user);

        // Assert
        result.Should().Throw<ValidationException>().WithMessage(errorMessage);
    }
    
    [Fact]
    public void CreateAccount_WithValidPassword_ShouldNotThrowException()
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        var user = new RegisterRequest()
        {
            username = "test",
            email = "thisisavalid@email.com",
            password = "thisisavalidpassword",
        };
        
        // Act
        Action result = () => service.Create(user);

        // Assert
        result.Should().NotThrow<ValidationException>();
    }
    
    /*
     * Helper Class /w methods for Tests Setup
     */
    private ServiceSetup CreateServiceSetup()
    {
        var repoMock = new Mock<IAccountRepository>();
        var validator = new UserValidator();
        var validatorDto = new RegisterRequestValidator();
        var hasher = new PasswordHasher();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();

        return new ServiceSetup(repoMock.Object, hasher, mapper, validator, validatorDto);
    }
    
    private class ServiceSetup
    {
        private IAccountRepository _accountRepository;
        private IPasswordHasher _passwordHasher;
        private IMapper _mapper;
        private UserValidator _userValidator;
        private RegisterRequestValidator _accountDtoValidator;

        public ServiceSetup(
            IAccountRepository accountRepository,
            IPasswordHasher passwordHasher,
            IMapper mapper,
            UserValidator userValidator,
            RegisterRequestValidator accountDtoValidator)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _userValidator = userValidator;
            _accountDtoValidator = accountDtoValidator;
        }

        public ServiceSetup WithAccountRepository(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            return this;
        }

        public ServiceSetup WithPasswordHasher(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            return this;
        }

        public ServiceSetup WithMapper(IMapper mapper)
        {
            _mapper = mapper;
            return this;
        }

        public ServiceSetup WithUserValidator(UserValidator userValidator)
        {
            _userValidator = userValidator;
            return this;
        }

        public ServiceSetup WithRegisterRequestDto(RegisterRequestValidator accountDtoValidator)
        {
            _accountDtoValidator = accountDtoValidator;
            return this;
        }

        public AccountService CreateService()
        {
            return new AccountService(
                _accountRepository,
                _passwordHasher,
                _mapper,
                _userValidator,
                _accountDtoValidator
            );
        }
    }
}