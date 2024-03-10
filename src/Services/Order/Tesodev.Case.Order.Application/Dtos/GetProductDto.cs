namespace Tesodev.Case.Order.Application.Dtos;

public class GetProductDto
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}