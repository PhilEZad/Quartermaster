using Application.DTOs;
using Application.DTOs.Requests;
using Application.Helpers;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces.Repositories;
using Application.Services;
using Application.Validators;
using Application.Validators.Factory;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;

namespace UnitTests.Services;


public class UnitTests
{
    [Fact]
    public void CreateService_WithNullUnitRepository_ShouldThrowNullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithRepository(null);

        //Act
        Action test = () => setup.CreateService();

        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("UnitRepository is null");
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
            .WithValidatorHelper(null);

        //Act
        Action test = () => setup.CreateService();

        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("ValidationHelper is null");
    }
    
    [Fact]
    public void CreateService_WithValidParameters_ShouldReturnFactionService()
    {
        //Arrange
        var setup = CreateServiceSetup();

        //Act
        var service = setup.CreateService();

        //Assert
        service.Should().BeOfType<UnitService>();
    }
    
    /*
     * CreateUnit Tests
     */

    [Fact]
    public void CreateUnit_WithObjectAsNull_ShouldThrowNullReferenceExceptionWithMessage()
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        // Act
        Action test = () => service.CreateUnit(null);
        
        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("Unit is null");
    }

    [Theory]
    [InlineData("", "Name is required")]
    [InlineData(" ", "Name is required")]
    [InlineData(null, "Name is required")]
    public void CreateUnit_WithInvalidNameProperty_ShouldThrowValidationExceptionWithMessage(string name,
        string message)
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        // Act
        Action test = () => service.CreateUnit(new UnitRequest
        {
            Name = name
        });

        // Assert
        test.Should().Throw<ValidationException>().WithMessage(message);
    }
    
    [Theory]
    [InlineData("", "Faction is required")]
    public void CreateUnit_WithValidNamePropertyAndInvalidFactionProperty_ShouldThrowValidationExceptionWithMessage(string faction,
        string message)
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        // Act
        Action test = () => service.CreateUnit(new UnitRequest
        {
            Name = "Unit",
            Faction = new Domain.Faction
            {
                Name = faction
            }
        });

        // Assert
        test.Should().Throw<ValidationException>().WithMessage(message);
    }

    /*
     * Helper Class /w methods for Tests Setup
     */
    private ServiceSetup CreateServiceSetup()
    {
        var repoMock = new Mock<IUnitRepository>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();
        var validatorHelper = new ValidationHelper(new ValidatorFactory());

        return new ServiceSetup(repoMock, mapper,validatorHelper);
    }

    private class ServiceSetup
    {
        private IUnitRepository _factionRepository;
        private IMapper _mapper;
        private IValidationHelper _validatorHelper;

        public ServiceSetup(
            Mock<IUnitRepository> repositoryMock,
            IMapper mapper,
            IValidationHelper validatorHelper

        )
        {
            _factionRepository = repositoryMock.Object;
            _mapper = mapper;
            _validatorHelper = validatorHelper;
        }

        public ServiceSetup WithRepository(IUnitRepository repositoryMock)
        {
            _factionRepository = repositoryMock;
            return this;
        }

        public ServiceSetup WithMapper(IMapper mapper)
        {
            _mapper = mapper;
            return this;
        }

        public ServiceSetup WithValidatorHelper(IValidationHelper validatorHelper)
        {
            _validatorHelper = validatorHelper;
            return this;
        }

        public UnitService CreateService()
        {
            return new UnitService(
                _factionRepository,
                _mapper,
                _validatorHelper
            );
        }
    }
}