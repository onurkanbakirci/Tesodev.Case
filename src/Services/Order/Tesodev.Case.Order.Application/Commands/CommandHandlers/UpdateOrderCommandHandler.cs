using AutoMapper;
using MediatR;
using Tesodev.Case.Order.Application.Commands;
using Tesodev.Case.Order.Application.Dtos;
using Tesodev.Case.Order.Application.Utilities.Results;
using Tesodev.Case.Order.Domain.AggregatesModel.OrderAggregate;

namespace Tesodev.Case.Order.Application.Commands.CommandHandlers;
public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, IDataResult<GetOrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<GetOrderDto>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(new Guid(request.OrderId));
        _mapper.Map(request, order);
        _orderRepository.Update(order);
        await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        var mappedOrder = _mapper.Map<GetOrderDto>(order);
        return new SuccessDataResult<GetOrderDto>(mappedOrder);
    }
}