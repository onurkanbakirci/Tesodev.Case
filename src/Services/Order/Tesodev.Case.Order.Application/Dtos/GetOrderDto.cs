namespace Tesodev.Case.Order.Application.Dtos;

public class GetOrderDto
{
    public Guid OrderId { get; set; }
    public GetAddressDto Address { get; set; }
    public GetProductDto Product { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string Status { get; set; }
}