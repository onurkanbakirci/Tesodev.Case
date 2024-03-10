using AutoFixture;

namespace Tesodev.Case.Customer.UnitTests.Domain;

public class CustomerAggregateTest
{
    private readonly Fixture _fixture;
    public CustomerAggregateTest()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void Handle_throws_exception_when_name_empty()
    {
        //Assert
        Assert.Throws<ArgumentNullException>(() => new Customer.Domain.AggregatesModel.CustomerAggregate.Customer("", _fixture.Create<string>()));
    }

    [Fact]
    public void Handle_throws_exception_when_email_empty()
    {
        //Assert
        Assert.Throws<ArgumentNullException>(() => new Customer.Domain.AggregatesModel.CustomerAggregate.Customer(_fixture.Create<string>(), ""));
    }
}