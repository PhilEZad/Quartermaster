using Application.DTOs;
using Application.DTOs.Requests;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Services;
using Application.Validators;
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
    public void CreateService_WithNullUnitRequestValidator_ShouldThrowNullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithRequestValidator(null);

        //Act
        Action test = () => setup.CreateService();

        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("UnitRequestValidator is null");
    }
    
    [Fact]
    public void CreateService_WithNullUnitValidator_ShouldThrowNullExceptionReferenceWithMessage()
    {
        //Arrange
        var setup = CreateServiceSetup()
            .WithValidator(null);

        //Act
        Action test = () => setup.CreateService();

        //Assert
        test.Should().Throw<NullReferenceException>().WithMessage("UnitValidator is null");
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

        var unitRequestValidators = new UnitRequestValidator();
        var unitValidator = new UnitValdiator();

        return new ServiceSetup(repoMock, mapper, unitRequestValidators, unitValidator);
    }

    private class ServiceSetup
    {
        private IUnitRepository _factionRepository;
        private IMapper _mapper;

        private UnitRequestValidator _factionRequestValidator;
        private UnitValdiator _factionValidator;

        public ServiceSetup(
            Mock<IUnitRepository> repositoryMock,
            IMapper mapper,

            UnitRequestValidator factionRequestValidators,
            UnitValdiator factionValidator
        )
        {
            _factionRepository = repositoryMock.Object;
            _mapper = mapper;

            _factionRequestValidator = factionRequestValidators;
            _factionValidator = factionValidator;
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

        public ServiceSetup WithRequestValidator(UnitRequestValidator loginRequestValidators)
        {
            _factionRequestValidator = loginRequestValidators;
            return this;
        }

        public ServiceSetup WithValidator(UnitValdiator validator)
        {
            _factionValidator = validator;
            return this;
        }

        public UnitService CreateService()
        {
            return new UnitService(
                _factionRepository,
                _mapper,
                _factionValidator,
                _factionRequestValidator
            );
        }
    }
}