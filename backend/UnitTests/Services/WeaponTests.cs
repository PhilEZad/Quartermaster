using Application.DTOs.Requests;
using Application.Helpers;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces.Repositories;
using Application.Services;
using Application.Validators.Factory;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;

namespace UnitTests.Services;

public class WeaponTests
{
    
    /*
     * CreateService Tests
     */
    [Fact]
    public void CreateService_WithNullRepository_ShouldThrowNullReferenceExceptionWithMessage()
    {
        // Arrange
        var setup = CreateServiceSetup()
            .WithRepository(null);

        // Act
        Action test = () => setup.CreateService();

        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("WeaponRepository is null");
    }
    
    [Fact]
    public void CreateService_WithNullMapper_ShouldThrowNullReferenceExceptionWithMessage()
    {
        // Arrange
        var setup = CreateServiceSetup()
            .WithMapper(null);

        // Act
        Action test = () => setup.CreateService();

        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("Mapper is null");
    }
    
    [Fact]
    public void CreateService_WithNullValidatorHelper_ShouldThrowNullReferenceExceptionWithMessage()
    {
        // Arrange
        var setup = CreateServiceSetup()
            .WithValidatorHelper(null);

        // Act
        Action test = () => setup.CreateService();

        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("ValidationHelper is null");
    }
    
    [Fact]
    public void CreateService_WithValidParameters_ShouldReturnFactionService()
    {
        // Arrange
        var setup = CreateServiceSetup();

        // Act
        var service = setup.CreateService();

        // Assert
        service.Should().NotBeNull();
    }
    
    /*
     * Creation Tests
     */

    [Fact]
    public void CreateWeapon_WithNullObject_ShouldThrowNullReferenceExceptionWithMessage()
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        // Act
        Action test = () => service.CreateWeapon(null);
        
        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("WeaponRequest is null");
    }

    [Theory]
    [InlineData("", "Name can not be empty")]
    [InlineData(" ", "Name can not be empty")]
    [InlineData(null, "Name can not be null")]
    public void CreateWeapon_WithInvalidName_ShouldThrowValidationExceptionWithMessage(string name, string message)
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        var weapon = new WeaponRequest
        {
            Name = name
        };
        
        // Act
        Action test = () => service.CreateWeapon(weapon);
        
        //Assert
        test.Should().Throw<ValidationException>().WithMessage(message);
    }
    
    [Fact]
    public void CreateWeapon_WithValidObject_ShouldReturnWeaponResponse()
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        // Act
        var response = service.CreateWeapon(new WeaponRequest());
        // Assert
        response.Should().NotBeNull();
    }
    
    /*
     * Read Tests
     */
    
    /*  
     * Update Tests
     */
    
    /*
     * Delete Tests
     */
    
    /*
     * Helper Methods
     */
    
    private ServiceSetup CreateServiceSetup()
    {
        var repoMock = new Mock<IWeaponRepository>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();
        var validatorHelper = new ValidationHelper(new ValidatorFactory());

        return new ServiceSetup(repoMock, mapper,validatorHelper);
    }

    private class ServiceSetup
    {
        private IWeaponRepository _weaponRepository;
        private IMapper _mapper;
        private IValidationHelper _validatorHelper;

        public ServiceSetup(
            Mock<IWeaponRepository> repositoryMock,
            IMapper mapper,
            IValidationHelper validatorHelper

        )
        {
            _weaponRepository = repositoryMock.Object;
            _mapper = mapper;
            _validatorHelper = validatorHelper;
        }

        public ServiceSetup WithRepository(IWeaponRepository repositoryMock)
        {
            _weaponRepository = repositoryMock;
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

        public WeaponService CreateService()
        {
            return new WeaponService(
                _weaponRepository,
                _mapper,
                _validatorHelper
            );
        }
    }
}