using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Validators;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication;
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
        test.Should().Throw<NullReferenceException>().WithMessage("AccountRepository cannot be null");
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
        test.Should().Throw<NullReferenceException>().WithMessage("Mapper cannot be null");
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
        test.Should().Throw<NullReferenceException>().WithMessage("LoginRequestValidator cannot be null");
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
        test.Should().Throw<NullReferenceException>().WithMessage("LoginResponseValidator cannot be null");
    }
    
    
    private ServiceSetup CreateServiceSetup()
    {
        var repoMock = new Mock<IAccountRepository>();
        var loginRequestValidators = new LoginRequestValidators();
        var loginResponseValidators = new LoginResponseValidators();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();

        return new ServiceSetup(repoMock, mapper, loginRequestValidators, loginResponseValidators);
    }
    
    private class ServiceSetup
    {
        private IAccountRepository _repository;
        private IMapper _mapper;
        
        private LoginRequestValidators _loginRequestValidator;
        private LoginResponseValidators _loginResponseValidator;

        public ServiceSetup(
            Mock<IAccountRepository> repositoryMock,
            IMapper mapper,
            
            LoginRequestValidators loginRequestValidators,
            LoginResponseValidators loginResponseValidators
        )
        {
            _repository = repositoryMock.Object;
            _mapper = mapper;
            
            _loginRequestValidator = loginRequestValidators;
            _loginResponseValidator = loginResponseValidators;
        }

        public ServiceSetup WithAccountRepository(IAccountRepository repositoryMock)
        {
            _repository = repositoryMock;
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


        public AuthenticationService CreateService()
        {
            return new AuthenticationService(
                _accountRepository,
                _mapper,
                _loginRequestValidator,
                _loginResponseValidator
            );
        }
    }
}