using Application.Helpers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using AutoMapper;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTests.Services;

public class FactionTests
{
    // Service Creation Tests
    
    [Fact]
    public void CreateService_WithNullFactionRepository_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithFactionRepository(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("FactionRepository is null");
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
    public void CreateService_WithNullFactionRequestValidator_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithFactionRequestValidator(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("FactionRequestValidator is null");
    }
    
    [Fact]
    public void CreateService_WithNullFactionResponseValidator_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithFactionResponseValidator(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("FactionResponseValidator is null");
    }
    
    [Fact]
    public void CreateService_WithNullFactionValidator_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithFactionValidator(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("FactionValidator is null");
    }
    
    [Fact]
    public void CreateService_WithValidParameters_ReturnsService()
    {
        //Arrange
        var setup = CreateServiceSetup();
        
        //Act
        var service = setup.CreateService();
        
        //Assert
        service.Should().NotBeNull();
    }
    
    /*
     * Helper Class /w methods for Tests Setup
     */
    private ServiceSetup CreateServiceSetup()
    {
        var repoMock = new Mock<IAccountRepository>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();

        var factionRequestValidators = new FactionRequestValidators();
        var factionResponseValidators = new FactionResponseValidators();
        var factionValidator = new FactionValidator();

        return new ServiceSetup(repoMock, mapper, factionRequestValidators, factionResponseValidators, factionValidator);
    }
    
    private class ServiceSetup
    {
        private IAccountRepository _accountRepository;
        private IMapper _mapper;

        private FactionRequestValidators _factionRequestValidator;
        private FactionResponseValidators _factionResponseValidator;
        private FactionValidator _factionValidator;

        public ServiceSetup(
            Mock<IFactionRepository> repositoryMock,
            IMapper mapper,
            IJwtProvider jwtProvider,

            FactionRequestValidators factionRequestValidators,
            FactionResponseValidators factionResponseValidators,
            Faction factionValidator
        )
        {
            _accountRepository = repositoryMock.Object;
            _mapper = mapper;

            _factionRequestValidator = factionRequestValidators;
            _factionResponseValidator = factionResponseValidators;
            _factionValidator = factionValidator;
        }

        public ServiceSetup WithAccountRepository(IFactionService repositoryMock)
        {
            _accountRepository = repositoryMock;
            return this;
        }

        public ServiceSetup WithMapper(IMapper mapper)
        {
            _mapper = mapper;
            return this;
        }

        public ServiceSetup WithLoginRequestValidator(FactionRequestValidators loginRequestValidators)
        {
            _factionRequestValidator = loginRequestValidators;
            return this;
        }
        
        public ServiceSetup WithLoginResponseValidator(FactionResponseValidators loginResponseValidators)
        {
            _factionResponseValidator = loginResponseValidators;
            return this;
        }
        
        public ServiceSetup WithUserValidator(FactionValidator userValidator)
        {
            _factionValidator = userValidator;
            return this;
        }

        public FactionService CreateService()
        {
            return new FactionService(
                _factionRepository,
                _mapper,
                _factionRequestValidator,
                _factionResponseValidator,
                _factionValidator
            );
        }
    }
}