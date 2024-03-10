using Tesodev.Case.Order.Domain.SeedWork;

namespace Tesodev.Case.Order.Domain.AggregatesModel.OrderAggregate;
public class OrderProduct : ValueObject
{
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public string Name { get; private set; }
    public string ImageUrl { get; private set; }

    public OrderProduct() { }

    public OrderProduct(Guid orderId, Guid productId, string name, string imageUrl)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name must be not null or empty");

        if (string.IsNullOrEmpty(imageUrl))
            throw new ArgumentException("ImageUrl must be not null or empty");

        OrderId = orderId;
        ProductId = productId;
        Name = name;
        ImageUrl = imageUrl;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return OrderId;
        yield return ProductId;
        yield return Name;
        yield return ImageUrl;
    }
}