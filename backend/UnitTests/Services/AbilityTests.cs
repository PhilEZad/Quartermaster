using Application.DTOs.Requests;
using Application.DTOs.Responses;
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

public class AbilityTests
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
        test.Should().Throw<NullReferenceException>().WithMessage("AbilityRepository is null");
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
    
    /*
     * Creation Test
     */
    
    [Fact]
    public void CreateAbility_WithNullRequest_ShouldThrowNullReferenceExceptionWithMessage()
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        // Act
        Action test = () => service.CreateAbility(null);

        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("AbilityRequest cannot be null");
    }

    [Fact]
    public void CreateAbility_WithValidRequest_ShouldReturnAbilityResponse()
    {
        // Arrange
        var mockRepo = new Mock<IAbilityRepository>();
        var setup = CreateServiceSetup().WithRepository(mockRepo.Object);
        var service = setup.CreateService();

        mockRepo.Setup(x => x.CreateAbility(It.IsAny<Ability>())).Returns(new Ability
        {
            Id = 1,
            Name = "Ability",
            Description = "Description"
        });
        
        // Act
        var response = service.CreateAbility(
            new AbilityRequest
            {
                Name = "Ability",
                Description = "Description"
            });

    // Assert
        response.Should().NotBeNull();
    }
    
    [Theory]
    [InlineData("", "Name is empty")]
    [InlineData(" ", "Name is empty")]
    [InlineData(null, "Name is null")]
    public void CreateAbility_WithInvalidName_ShouldThrowValidationExceptionWithMessage(string name, string message)
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        
        
        // Act
        Action test = () => service.CreateAbility(new AbilityRequest
        {
            Name = name,
            Description = "Description"
        });

        // Assert
        test.Should().Throw<ValidationException>().WithMessage(message);
    }
    
    [Theory]
    [InlineData(null, "Description is null")]
    public void CreateAbility_WithInvalidDescription_ShouldThrowValidationExceptionWithMessage(string description, string message)
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        // Act
        Action test = () => service.CreateAbility(new AbilityRequest
        {
            Name = "Ability",
            Description = description
        });

        // Assert
        test.Should().Throw<ValidationException>().WithMessage(message);
    }
    
    /*
     * Read Tests
     */
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GetAbility_WithInvalidId_ShouldThrowNullReferenceExceptionWithMessage(int id)
    {
        // Arrange
        var setup = CreateServiceSetup();
        var service = setup.CreateService();

        // Act
        Action test = () => service.GetAbilityById(id);

        // Assert
        test.Should().Throw<ValidationException>().WithMessage("Invalid Id");
    }
    
    [Fact]
    public void GetAbility_ReturningNullObject_ShouldThrowNullReferenceExceptionWithMessage()
    {
        // Arrange
        var mockRepo = new Mock<IAbilityRepository>();
        var setup = CreateServiceSetup().WithRepository(mockRepo.Object);
        var service = setup.CreateService();

        mockRepo.Setup(x => x.GetAbilityById(It.IsAny<int>())).Returns((Ability) null);
        
        // Act
        Action test = () => service.GetAbilityById(1);

        // Assert
        test.Should().Throw<NullReferenceException>().WithMessage("Ability is null");
    }
    
    [Fact]
    public void GetAbility_WithValidId_ShouldReturnAbilityResponse()
    {
        // Arrange
        var mockRepo = new Mock<IAbilityRepository>();
        var setup = CreateServiceSetup().WithRepository(mockRepo.Object);
        var service = setup.CreateService();

        mockRepo.Setup(x => x.GetAbilityById(It.IsAny<int>())).Returns(new Ability
        {
            Id = 1,
            Name = "Ability",
            Description = "Description"
        });
        
        // Act
        var response = service.GetAbilityById(1);

        // Assert
        response.Should().NotBeNull();
    }
    
    /*
     * Helper Methods
     */
    
    private ServiceSetup CreateServiceSetup()
    {
        var repoMock = new Mock<IAbilityRepository>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();
        var validatorHelper = new ValidationHelper(new ValidatorFactory());

        return new ServiceSetup(repoMock, mapper,validatorHelper);
    }

    private class ServiceSetup
    {
        private IAbilityRepository _abilityRepository;
        private IMapper _mapper;
        private IValidationHelper _validatorHelper;

        public ServiceSetup(
            Mock<IAbilityRepository> repositoryMock,
            IMapper mapper,
            IValidationHelper validatorHelper

        )
        {
            _abilityRepository = repositoryMock.Object;
            _mapper = mapper;
            _validatorHelper = validatorHelper;
        }

        public ServiceSetup WithRepository(IAbilityRepository repositoryMock)
        {
            _abilityRepository = repositoryMock;
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

        public AbilityService CreateService()
        {
            return new AbilityService(
                _abilityRepository,
                _mapper,
                _validatorHelper
            );
        }
    }
}