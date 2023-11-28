using Application.Services;
using Domain;
using FluentAssertions;
using Infrastructure.Repositories;

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
}