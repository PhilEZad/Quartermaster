using Application.DTOs;
using Application.Helpers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentAssertions;
using FluentValidation;
using Moq;

namespace UnitTests.Services;

public class FactionTests
{
    // Service Creation Tests
    
    [Fact]
    public void CreateService_WithNullFactionRepository_ShouldThrowNullExceptionReferenceWithMessage()
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
    public void CreateService_WithNullMapper_ShouldThrowNullExceptionReferenceWithMessage()
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
    public void CreateService_WithNullFactionRequestValidator_ShouldThrowNullExceptionReferenceWithMessage()
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
    public void CreateService_WithNullFactionResponseValidator_ShouldThrowNullExceptionReferenceWithMessage()
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
    public void CreateService_WithNullFactionValidator_ShouldThrowNullExceptionReferenceWithMessage()
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
     * CreateFaction Tests
     */
    
    [Fact]
    public void CreateFaction_WithNullFactionRequest_ShouldThrowNullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        //Act
        Action test = () => service.CreateFaction(null);
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("FactionRequest is null");
    }
    
    [Theory]
    [InlineData("", "Name is required")]
    [InlineData(" ", "Name is required")]
    [InlineData(null, "Name is required")]
    [InlineData("This is a test name that is way too long for the validation", "Name must be between 1 and 50 characters")]
    [InlineData("Тестовое сообщение", "Faction name must only contain alphanumeric characters")]
    public void CreateFaction_WithInvalidFactionRequestName_ShouldThrowValidationExceptionWithMessage(string TestName, string ErrorMessage)
    {
        //Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        var factionRequest = new FactionRequest
        {
            Name = TestName,
            Description = "This is an example of a test faction",
        };
        
        //Act
        Action test = () => service.CreateFaction(factionRequest);
        
        //Assert
        test.Should().Throw<ValidationException>().WithMessage(ErrorMessage);
    }

    [Fact]
    public void CreateFaction_WithInvalidFactionRequestDescription_ShouldThrowValicationExceptionWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        //Act
        Action test = () => service.CreateFaction(new FactionRequest
        {
            Name = "Test Faction",
            Description = null
        });
        
        //Assert
        test.Should().Throw<ValidationException>().WithMessage("Description is null");
    }
    
    [Fact]
    public void CreateFaction_WithNullReturnFaction_ShouldThrowNullReferenceErrorWithMessage()
    {
        //Arrange
        var repoMock = new Mock<IFactionRepository>();
        
        var setup = CreateServiceSetup().WithRepository(repoMock.Object);

        repoMock.Setup(x => x.CreateFaction(
            It.IsAny<Faction>())).Returns((Faction)null);
        
        var service = setup.CreateService();

        //Act
        Action test = () => service.CreateFaction(new FactionRequest
        {
            Name = "Test Faction",
            Description = "This is an example of a test faction"
        });
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("Return Faction is null");
    }
    
    /*
     * GetFaction Tests
     */
    
    /*
     * UpdateFactions Tests
     */
    
    /*
     * DeleteFaction Tests
     */
    
    /*
     * Helper Class /w methods for Tests Setup
     */
    private ServiceSetup CreateServiceSetup()
    {
        var repoMock = new Mock<IFactionRepository>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();

        var factionRequestValidators = new FactionRequestValidator();
        var factionResponseValidators = new FactionResponseValidator();
        var factionValidator = new FactionValidator();

        return new ServiceSetup(repoMock, mapper, factionRequestValidators, factionResponseValidators, factionValidator);
    }
    
    private class ServiceSetup
    {
        private IFactionRepository _factionRepository;
        private IMapper _mapper;

        private FactionRequestValidator _factionRequestValidator;
        private FactionResponseValidator _factionResponseValidator;
        private FactionValidator _factionValidator;

        public ServiceSetup(
            Mock<IFactionRepository> repositoryMock,
            IMapper mapper,

            FactionRequestValidator factionRequestValidator,
            FactionResponseValidator factionResponseValidator,
            FactionValidator factionValidator
        )
        {
            _factionRepository = repositoryMock.Object;
            _mapper = mapper;

            _factionRequestValidator = factionRequestValidator;
            _factionResponseValidator = factionResponseValidator;
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

        public ServiceSetup WithRequestValidator(FactionRequestValidator loginRequestValidator)
        {
            _factionRequestValidator = loginRequestValidator;
            return this;
        }
        
        public ServiceSetup WithResponseValidator(FactionResponseValidator loginResponseValidator)
        {
            _factionResponseValidator = loginResponseValidator;
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