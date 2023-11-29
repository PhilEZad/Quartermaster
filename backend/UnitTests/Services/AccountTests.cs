using Application.Interfaces;
using Application.Services;
using Domain;
using FluentAssertions;
using Infrastructure.Repositories;
using Moq;

namespace UnitTests.Services;


public class AccountTests
{
    [Fact]
    public void CreateServiceWithNull_ShouldThrowNullReferenceException()
    {
        Action test = () => new AccountService(null);

        test.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void CreateServiceWithValidRepository_ShouldNotThrowNullReferenceException()
    {
        Action test = () => new AccountService(new AccountRepository());

        test.Should().NotThrow<NullReferenceException>();
    }
    
    /*
     * Account Creation Tests
     */
    
    [Fact]
    public void CreateAccountWithNull_ShouldThrowNullReferenceException()
    {
        var repo = new Mock<IAccountRepository>();
        AccountService service = new(repo.Object);
        
        Action test = () => service.Create(null);

        test.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void CreateAccountWithValidObject_ShouldNotThrowNullReferenceException()
    {
        var repo = new Mock<IAccountRepository>();
        AccountService service = new(repo.Object);

        var user = new User
        {
            id = 1,
            userName = "test",
            password = "test",
        };
        
        Action test = () => service.Create(user);

        test.Should().NotThrow<NullReferenceException>();
    }
    
    [Fact]
    public void CreateAccountSuccess_ShouldReturnTrue()
    {
        var repo = new Mock<IAccountRepository>();
        AccountService service = new(repo.Object);

        var user = new User
        {
            id = 1,
            userName = "test",
            password = "test",
        };
        
        Action result = () => service.Create(user);

        result.Should().NotThrow<Exception>();
    }
    
    [Fact]
    public void CreateAccountFailure_ShouldReturnFalse()
    {
        var repo = new Mock<IAccountRepository>();
        AccountService service = new(repo.Object);

        var user = new User
        {
            id = 1,
            userName = "test",
            password = "test",
        };
        
        Action result = () => service.Create(user);

        result.Should().Throw<Exception>().WithMessage("Failed to create account");
    }
    
    [Fact]
    public void CreateAccountWithExistingUser_ShouldReturnMessage()
    {
        var repo = new Mock<IAccountRepository>();
        AccountService service = new(repo.Object);

        var user = new User
        {
            id = 1,
            userName = "test",
            password = "test",
        };
        
        Action result = () => service.Create(user);

        result.Should().Throw<Exception>().WithMessage("User already exists");
    }
    
    [Theory]
    [InlineData(null,"Password can not be null")]
    [InlineData("", "Password can not be empty")]
    [InlineData("1234","Password must be more than 8 characters")]
    public void CreateAccountWithInvalidPassword_ShouldReturnMessage(String password, String errorMessage)
    {
        var repo = new Mock<IAccountRepository>();
        AccountService service = new(repo.Object);

        var user = new User
        {
            id = 1,
            userName = "test",
            password = password,
        };
        
        Action result = () => service.Create(user);

        result.Should().Throw<Exception>().WithMessage(errorMessage);
    }
    
    /*
     * Account Login Tests
     */
}