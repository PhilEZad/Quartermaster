using Application.DTOs;
using Application.Helpers;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.Validators;
using Application.Validators.Factory;
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
    public void CreateService_WithNullValidatorHelper_ShouldThrowNullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithValidator(null);
        
        //Act
        Action test = () => setup.CreateService();
        
        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("ValidatorHelper is null");
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
    [InlineData("", "Name can not be empty")]
    [InlineData(" ", "Name can not be empty")]
    [InlineData(null, "Name can not be empty")]
    [InlineData("This is a test name that is way too long for the validation", "Name can not be more than 50 characters")]
    public void CreateFaction_WithInvalidFactionRequestName_ShouldThrowValidationExceptionWithMessage(string TestName, string ErrorMessage)
    {
        //Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        var factionRequest = new Application.DTOs.Requests.FactionRequest
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
        Action test = () => service.CreateFaction(new Application.DTOs.Requests.FactionRequest
        {
            Name = "Test Faction",
            Description = null
        });
        
        //Assert
        test.Should().Throw<ValidationException>().WithMessage("Description can not be empty");
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
        Action test = () => service.CreateFaction(new Application.DTOs.Requests.FactionRequest
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

        IValidationHelper validationHelper = new ValidationHelper(new ValidatorFactory());

        return new ServiceSetup(repoMock, mapper, validationHelper);
    }
    
    private class ServiceSetup
    {
        private IFactionRepository _factionRepository;
        private IMapper _mapper;

        private IValidationHelper _validationHelper;

        public ServiceSetup(
            Mock<IFactionRepository> repositoryMock,
            IMapper mapper,

            IValidationHelper validationHelper)
        {
            _factionRepository = repositoryMock.Object;
            _mapper = mapper;

            _validationHelper = validationHelper;
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
        
        public ServiceSetup WithValidator(IValidationHelper validationHelper)
        {
            _validationHelper = validationHelper;
            return this;
        }

        public FactionService CreateService()
        {
            return new FactionService(
                _factionRepository,
                _mapper,
                _validationHelper
            );
        }
    }
}