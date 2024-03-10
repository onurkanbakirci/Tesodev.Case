using AutoMapper;
using MediatR;
using Tesodev.Case.Order.Application.Utilities.Results;
using Tesodev.Case.Order.Domain.AggregatesModel.OrderAggregate;

namespace Tesodev.Case.Order.Application.Commands.CommandHandlers;
public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, IResult<bool>>
{
    private readonly IOrderRepository _orderRepository;
    public DeleteOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IResult<bool>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(new Guid(request.OrderId));
        _orderRepository.Delete(order);
        await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return new SuccessResult<bool>(true);
    }
}