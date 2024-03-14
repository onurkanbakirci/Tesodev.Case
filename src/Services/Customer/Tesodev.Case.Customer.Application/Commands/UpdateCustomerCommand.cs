using MediatR;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Application.Utilities.Results;

namespace Tesodev.Case.Customer.Application.Commands;
public class UpdateCustomerCommand : IRequest<IDataResult<GetCustomerDto>>
{
    public string CustomerId { get; set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public UpdateCustomerCommand(string customerId, string name, string email)
    {
        CustomerId = customerId;
        Name = name;
        Email = email;
    }
}