using MediatR;
using AutoMapper;
using Tesodev.Case.Order.Application.Dtos;
using Tesodev.Case.Order.Application.Utilities.Results;
using Tesodev.Case.Order.Domain.AggregatesModel.OrderAggregate;

namespace Tesodev.Case.Order.Application.Queries.Handlers;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IResult<List<GetOrderDto>>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IResult<List<GetOrderDto>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAsync();

        var mappedOrders = _mapper.Map<List<GetOrderDto>>(orders);

        return new SuccessResult<List<GetOrderDto>>(mappedOrders);
    }
}