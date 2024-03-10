namespace Tesodev.Case.Customer.Application.Dtos;

public class GetCustomerDto
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public GetAddressDto Address { get; set; }
}