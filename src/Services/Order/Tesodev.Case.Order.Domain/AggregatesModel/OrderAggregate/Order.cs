using Tesodev.Case.Order.Domain.SeedWork;
namespace Tesodev.Case.Order.Domain.AggregatesModel.OrderAggregate;
public class Order : Entity, IAggregateRoot
{
    private int _quantity;
    private Guid _customerId;
    private double _price;
    public OrderAddress Address { get; private set; }
    public string _status;
    public OrderProduct Product { get; private set; }

    public Order()
    {
    }

    public Order(Guid customerId) : this()
    {
        _customerId = customerId;
        _status = OrderStatus.Submitted.Name;
    }

    public Order SetOrderProduct(Guid productId, string name, string imageUrl, double unitPrice, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than 0");
        _quantity = quantity;

        if (unitPrice <= 0)
            throw new ArgumentException("Unit price must be greater than 0");
        _price = unitPrice * quantity;

        if (_price <= 0)
            throw new ArgumentException("Price must be greater than 0");

        Product = new OrderProduct(Id, productId, name, imageUrl);

        return this;
    }

    public Order SetOrderAddress(string addressLine, string city, string country, int cityCode)
    {
        Address = new OrderAddress(Id, addressLine, city, country, cityCode);

        return this;
    }

    public void ChangeOrderStatus(string status)
    {
        if (OrderStatus.FromName(status) is null)
            throw new ArgumentException("It's not valid status");
        _status = status;
    }

    public int GetQuantity() => _quantity;
    public double GetPrice() => _price;
    public string GetStatus() => _status;
}