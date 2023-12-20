using Application.DTOs.Requests;
using Application.DTOs.Updates;
using Application.Helpers;
using Application.Helpers.Helper_Interfaces;
using Application.Interfaces.Repositories;
using Application.Services;
using Application.Validators.Factory;
using AutoMapper;
using Domain;
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
    [InlineData("", "Name is required")]
    [InlineData(" ", "Name is required")]
    [InlineData(null, "Name is null")]
    public void CreateWeapon_WithInvalidName_ShouldThrowValidationExceptionWithMessage(string name, string message)
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();
        
        var weapon = new WeaponRequest
        {
            Name = name,
            Faction = new Faction(),
            Range = 1,
            Type = "Melee",
            Strength = 1,
            ArmourPenetration = 1,
            Damage = 1,
            Abilities = new List<Ability>(),
            Points = 1
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
        var mockRepo = new Mock<IWeaponRepository>();
        var setup = CreateServiceSetup().WithRepository(mockRepo.Object);
        var service = setup.CreateService();
        
        mockRepo.Setup(x => x.Create(It.IsAny<Weapon>())).Returns(new Weapon
        {
            Id = 1,
            Name = "Test Weapon",
            Faction = new Faction(),
            Range = 1,
            Type = "Melee",
            Strength = 1,
            ArmourPenetration = 1,
            Damage = 1,
            Abilities = new List<Ability>(),
            Points = 1
        });
        
        // Act
        var response = service.CreateWeapon(new WeaponRequest
        {
            Name = "Test Weapon",
            Faction = new Faction(),
            Range = 1,
            Type = "Melee",
            Strength = 1,
            ArmourPenetration = 1,
            Damage = 1,
            Abilities = new List<Ability>(),
            Points = 1
        });
        
        // Assert
        response.Should().NotBeNull();
    }
    
    [Fact]
    public void CreateWeapon_WithValidObject_ShouldThrowNoErrors()
    {
        // Arrange
        var mockRepo = new Mock<IWeaponRepository>();
        var setup = CreateServiceSetup().WithRepository(mockRepo.Object);
        var service = setup.CreateService();
        
        mockRepo.Setup(x => x.Create(It.IsAny<Weapon>())).Returns(new Weapon
        {
            Id = 1,
            Name = "Test Weapon",
            Faction = new Faction(),
            Range = 1,
            Type = "Melee",
            Strength = 1,
            ArmourPenetration = 1,
            Damage = 1,
            Abilities = new List<Ability>(),
            Points = 1
            
        });
        
        // Act
        var test = () => service.CreateWeapon(new WeaponRequest
        {
            Name = "Test Weapon",
            Faction = new Faction(),
            Range = 1,
            Type = "Melee",
            Strength = 1,
            ArmourPenetration = 1,
            Damage = 1,
            Abilities = new List<Ability>(),
            Points = 1
        });
        
        // Assert
        test.Should().NotThrow<Exception>();
    }
    
    /*
     * Read Tests
     */
    
    [Fact]
    public void GetAllWeapons_ReturnListBeingNull_ShouldThrowNullReferenceExceptionWithMessage()
    {
        // Arrange
        var mockRepo = new Mock<IWeaponRepository>();
        var setup = CreateServiceSetup().WithRepository(mockRepo.Object);
        var service = setup.CreateService();
        
        mockRepo.Setup(x => x.GetAllWeapons()).Returns((List<Weapon>) null);
        
        // Act
        Action test = () => service.GetAllWeapons();
        
        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("Weapons list is null");
    }
    
    [Fact]
    public void GetWeaponsByFaction_ReturnListBeingNull_ShouldThrowNullReferenceExceptionWithMessage()
    {
        // Arrange
        var mockRepo = new Mock<IWeaponRepository>();
        var setup = CreateServiceSetup().WithRepository(mockRepo.Object);
        var service = setup.CreateService();
        
        mockRepo.Setup(x => x.GetWeaponsByFactionId(It.IsAny<int>())).Returns((List<Weapon>) null);
        
        // Act
        Action test = () => service.GetWeaponByFactionId(1);
        
        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("Weapons list is null");
    }
    
    /*  
     * Update Tests
     */

    [Fact]
    public void UpdateWeapon_WithValidObject_ShouldReturnUpdatedObjec()
    {
        // Arrange
        var mockRepo = new Mock<IWeaponRepository>();
        var setup = CreateServiceSetup().WithRepository(mockRepo.Object);
        var service = setup.CreateService();

        mockRepo.Setup(x => x.Update(It.IsAny<Weapon>())).Returns(new Weapon
        {
            Id = 1,
            Name = "Test Weapon Updated",
            Faction = new Faction(),
            Range = 1,
            Type = "Melee",
            Strength = 1,
            ArmourPenetration = 1,
            Damage = 1,
            Abilities = new List<Ability>(),
            Points = 1
        });
        
        var weapon = new WeaponUpdate
        {
            Id = 1,
            Name = "Test Weapon",
            Faction = new Faction(),
            Range = 1,
            Type = "Melee",
            Strength = 1,
            ArmourPenetration = 1,
            Damage = 1,
            Abilities = new List<Ability>(),
            Points = 1
        };
        
        // Act
        var test = () => service.UpdateWeapon(weapon);

        // Assert
        test.Should().NotThrow<Exception>();
    }
    
    /*
     * Delete Tests
     */
    
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void DeleteWeapon_WithInvalidId_ShouldThrowNullReferenceExceptionWithMessage(int id)
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        // Act
        Action test = () => service.DeleteWeapon(id);
        
        // Assert
        test.Should().Throw<ValidationException>().WithMessage("Invalid ID");
    }
    
    [Fact]
    public void DeleteWeapon_WithValidId_ShouldReturnTrue()
    {
        // Arrange
        var mockRepo = new Mock<IWeaponRepository>();
        var setup = CreateServiceSetup().WithRepository(mockRepo.Object);
        var service = setup.CreateService();
        
        mockRepo.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
        
        // Act
        var response = service.DeleteWeapon(1);
        
        // Assert
        response.Should().BeTrue();
    }
    
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