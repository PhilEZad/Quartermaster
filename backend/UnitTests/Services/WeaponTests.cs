using Application.Helpers;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces.Repositories;
using Application.Services;
using Application.Validators.Factory;
using AutoMapper;
using FluentAssertions;
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

        public UnitService CreateService()
        {
            return new WeaponService(
                _weaponRepository,
                _mapper,
                _validatorHelper
            );
        }
    }
}