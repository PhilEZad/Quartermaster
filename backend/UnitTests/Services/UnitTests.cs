using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Services;
using Application.Validators;
using AutoMapper;
using FluentAssertions;
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
        test.Should().Throw<NullReferenceException>().WithMessage("UnitRequestValidators is null");
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
     * Helper Class /w methods for Tests Setup
     */
    private ServiceSetup CreateServiceSetup()
    {
        var repoMock = new Mock<IFactionRepository>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();

        var unitRequestValidators = new UnitRequestValidator();
        var unitValidator = new UnitValdiator();

        return new ServiceSetup(repoMock, mapper, unitRequestValidators, unitValidator);
    }

    private class ServiceSetup
    {
        private IFactionRepository _factionRepository;
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
                _factionRequestValidator,
            );
        }
    }
}