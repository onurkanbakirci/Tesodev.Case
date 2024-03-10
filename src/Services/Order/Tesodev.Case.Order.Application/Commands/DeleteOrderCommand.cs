using MediatR;
using Tesodev.Case.Order.Application.Utilities.Results;

namespace Tesodev.Case.Order.Application.Commands;
public class DeleteOrderCommand: IRequest<IResult<bool>>
{
    public string OrderId { get; private set; }

    public DeleteOrderCommand(string orderId)
    {
        OrderId = orderId;
    }
}