using MediatR;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Application.Utilities.Results;

namespace Tesodev.Case.Customer.Application.Commands;
public class AddCustomerCommand : IRequest<IResult<GetCustomerDto>>
{
    public string Name { get; private set; }

    public string Email { get; private set; }

    public string AddressLine { get; private set; }

    public string City { get; private set; }

    public string Country { get; private set; }

    public int CityCode { get; private set; }

    public AddCustomerCommand(string name, string email, string addressLine, string city, string country, int cityCode)
    {
        Name = name;
        Email = email;
        AddressLine = addressLine;
        City = city;
        Country = country;
        CityCode = cityCode;
    }
}