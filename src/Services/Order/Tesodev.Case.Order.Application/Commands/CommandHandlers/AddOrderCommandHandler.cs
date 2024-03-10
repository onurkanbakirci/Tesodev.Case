using AutoMapper;
using MediatR;
using Tesodev.Case.Order.Application.Dtos;
using Tesodev.Case.Order.Application.Utilities.Results;
using Tesodev.Case.Order.Domain.AggregatesModel.OrderAggregate;

namespace Tesodev.Case.Order.Application.Commands.CommandHandlers;
public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, IResult<GetOrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public AddOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IResult<GetOrderDto>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Domain.AggregatesModel.OrderAggregate.Order(Guid.NewGuid());
        order.SetOrderProduct(new Guid(request.ProductId), request.ProductName, request.ProductImageUrl, request.ProductUnitPrice, request.ProductQuantity);
        order.SetOrderAddress(request.AddressLine, request.City, request.Country, request.CityCode);
        await _orderRepository.AddAsync(order);
        await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        var mappedCustomer = _mapper.Map<GetOrderDto>(order);
        return new SuccessResult<GetOrderDto>(mappedCustomer);
    }
}