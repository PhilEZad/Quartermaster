using Application.Helpers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.Validators;
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
            .WithRepository(null);
        
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
            .WithRequestValidator(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("FactionRequestValidators is null");
    }
    
    [Fact]
    public void CreateService_WithNullFactionResponseValidator_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithResponseValidator(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("FactionResponseValidators is null");
    }
    
    [Fact]
    public void CreateService_WithNullFactionValidator_NullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithValidator(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("FactionValidators is null");
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
        var repoMock = new Mock<IFactionRepository>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();

        var factionRequestValidators = new FactionRequestValidators();
        var factionResponseValidators = new FactionResponseValidators();
        var factionValidator = new FactionValidator();

        return new ServiceSetup(repoMock, mapper, factionRequestValidators, factionResponseValidators, factionValidator);
    }
    
    private class ServiceSetup
    {
        private IFactionRepository _factionRepository;
        private IMapper _mapper;

        private FactionRequestValidators _factionRequestValidator;
        private FactionResponseValidators _factionResponseValidator;
        private FactionValidator _factionValidator;

        public ServiceSetup(
            Mock<IFactionRepository> repositoryMock,
            IMapper mapper,

            FactionRequestValidators factionRequestValidators,
            FactionResponseValidators factionResponseValidators,
            FactionValidator factionValidator
        )
        {
            _factionRepository = repositoryMock.Object;
            _mapper = mapper;

            _factionRequestValidator = factionRequestValidators;
            _factionResponseValidator = factionResponseValidators;
            _factionValidator = factionValidator;
        }

        public ServiceSetup WithRepository(IFactionRepository repositoryMock)
        {
            _factionRepository = repositoryMock;
            return this;
        }

        public ServiceSetup WithMapper(IMapper mapper)
        {
            _mapper = mapper;
            return this;
        }

        public ServiceSetup WithRequestValidator(FactionRequestValidators loginRequestValidators)
        {
            _factionRequestValidator = loginRequestValidators;
            return this;
        }
        
        public ServiceSetup WithResponseValidator(FactionResponseValidators loginResponseValidators)
        {
            _factionResponseValidator = loginResponseValidators;
            return this;
        }
        
        public ServiceSetup WithValidator(FactionValidator userValidator)
        {
            _factionValidator = userValidator;
            return this;
        }

        public FactionService CreateService()
        {
            return new FactionService(
                _factionRepository,
                _mapper,
                _factionValidator,
                _factionRequestValidator,
                _factionResponseValidator
            );
        }
    }
}