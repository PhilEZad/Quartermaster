using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Services;
using Application.Validators;
using AutoMapper;
using FluentAssertions;
using Moq;

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
    /*
     * Helper Class /w methods for Tests Setup
     */
    private ServiceSetup CreateServiceSetup()
    {
        var repoMock = new Mock<IAccountRepository>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();
        
        var loginRequestValidators = new LoginRequestValidators();
        var loginResponseValidators = new LoginResponseValidators();
        var userValidator = new UserValidator();

        return new ServiceSetup(repoMock, mapper, loginRequestValidators, loginResponseValidators, userValidator);
    }
    
    private class ServiceSetup
    {
        private IAccountRepository _accountRepository;
        private IMapper _mapper;
        
        private LoginRequestValidators _loginRequestValidator;
        private LoginResponseValidators _loginResponseValidator;
        private UserValidator _userValidator;

        public ServiceSetup(
            Mock<IAccountRepository> repositoryMock,
            IMapper mapper,
            
            LoginRequestValidators loginRequestValidators,
            LoginResponseValidators loginResponseValidators,
            UserValidator userValidator
        )
        {
            _accountRepository = repositoryMock.Object;
            _mapper = mapper;
            
            _loginRequestValidator = loginRequestValidators;
            _loginResponseValidator = loginResponseValidators;
            _userValidator = userValidator;
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
                _loginRequestValidator,
                _loginResponseValidator,
                _userValidator
            );
        }
    }
}