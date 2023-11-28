using Domain;
using FluentAssertions;

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
    public void CreateAccountWithNullObject_ShouldThrowNullReferenceException()
    {
        Action test = () => new Account(null);

        test.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void CreateAccountWithValidUserObject_ShouldNotThrowNullReferenceException()
    {
        Action test = () => new Account(new User());

        test.Should().NotThrow<NullReferenceException>();
    }
    
    [Fact]
    public void CreateAccountWithEmptyName_ShouldThrowArgumentException()
    {
        Action test = () => new Account(new User() {userName = ""});

        test.Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void CreateAccountWithValidName_ShouldNotThrowArgumentException()
    {
        Action test = () => new Account(new User() {userName = "Test"});

        test.Should().NotThrow<ArgumentException>();
    }

    [Fact]
    public void CreateAccountWithInvalidName_ShouldThrowArgumentException()
    {
        Action test = () => new AccountTests()
    }
}