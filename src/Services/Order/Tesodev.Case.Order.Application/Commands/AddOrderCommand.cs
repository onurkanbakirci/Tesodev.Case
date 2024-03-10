using MediatR;
using Tesodev.Case.Order.Application.Dtos;
using Tesodev.Case.Order.Application.Utilities.Results;

namespace Tesodev.Case.Order.Application.Commands;
public class AddOrderCommand : IRequest<IResult<GetOrderDto>>
{
    public int ProductQuantity { get; private set; }

    public double ProductUnitPrice { get; private set; }

    public string ProductId { get; private set; }

    public string ProductName { get; private set; }

    public string ProductImageUrl { get; private set; }
    
    public string AddressLine { get; private set; }

    public string City { get; private set; }

    public string Country { get; private set; }

    public int CityCode { get; private set; }

    public AddOrderCommand(int productQuantity, double productUnitPrice, string productId, string productName, string productImageUrl, string addressLine, string city, string country, int cityCode)
    {
        ProductQuantity = productQuantity;
        ProductUnitPrice = productUnitPrice;
        ProductId = productId;
        ProductName = productName;
        ProductImageUrl = productImageUrl;
        AddressLine = addressLine;
        City = city;
        Country = country;
        CityCode = cityCode;
    }
}