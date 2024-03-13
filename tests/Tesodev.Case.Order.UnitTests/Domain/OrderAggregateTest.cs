using AutoFixture;

namespace Tesodev.Case.Order.UnitTests.Domain;

public class OrderAggregateTest
{
    private readonly Fixture _fixture;
    public OrderAggregateTest()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void Handle_throws_exception_when_quantity_not_valid()
    {
        //Arrange
        var order = new Order.Domain.AggregatesModel.OrderAggregate.Order(Guid.NewGuid());

        //Act - Assert
        Assert.Throws<ArgumentException>(() => order.SetOrderProduct(_fixture.Create<Guid>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<double>(), -1));
    }

    [Fact]
    public void Handle_throws_exception_when_price_not_valid()
    {
        //Arrange
        var order = new Order.Domain.AggregatesModel.OrderAggregate.Order(Guid.NewGuid());

        //Act - Assert
        Assert.Throws<ArgumentException>(() => order.SetOrderProduct(_fixture.Create<Guid>(), _fixture.Create<string>(), _fixture.Create<string>(), -1, 1));
    }
}