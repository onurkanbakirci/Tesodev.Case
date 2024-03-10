using MediatR;
using Tesodev.Case.Customer.Application.Utilities.Results;

namespace Tesodev.Case.Customer.Application.Commands;
public class DeleteCustomerCommand : IRequest<IResult<bool>>
{
    public string CustomerId { get; private set; }

    public DeleteCustomerCommand(string customerId)
    {
        CustomerId = customerId;
    }
}