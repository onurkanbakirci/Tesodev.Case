using MediatR;
using AutoMapper;
using Tesodev.Case.Order.Application.Dtos;
using Tesodev.Case.Order.Application.Utilities.Results;
using Tesodev.Case.Order.Domain.AggregatesModel.OrderAggregate;

namespace Tesodev.Case.Order.Application.Queries.Handlers;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, IResult<GetOrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IResult<GetOrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(new Guid(request.Id));

        var mappedOrder = _mapper.Map<GetOrderDto>(order);

        return new SuccessResult<GetOrderDto>(mappedOrder);
    }
}