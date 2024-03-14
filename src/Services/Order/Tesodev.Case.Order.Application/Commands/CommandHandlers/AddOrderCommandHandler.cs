using AutoMapper;
using MediatR;
using Tesodev.Case.Order.Application.Dtos;
using Tesodev.Case.Order.Application.Utilities.Results;
using Tesodev.Case.Order.Domain.AggregatesModel.OrderAggregate;
using Tesodev.Case.BuildingBlocks.Protos;

namespace Tesodev.Case.Order.Application.Commands.CommandHandlers;
public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, IDataResult<GetOrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly CustomerGrpc.CustomerGrpcClient _customerGrpcClient;
    private readonly IMapper _mapper;
    public AddOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, CustomerGrpc.CustomerGrpcClient customerGrpcClient)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _customerGrpcClient = customerGrpcClient;
    }

    public async Task<IDataResult<GetOrderDto>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerGrpcClient.GetCustomerByIdAsync(new GetCustomerByIdGrpcRequest { Id = request.CustomerId }) ?? throw new ArgumentNullException("Customer not found!");
        var order = new Domain.AggregatesModel.OrderAggregate.Order(Guid.NewGuid());
        order.SetOrderProduct(new Guid(request.ProductId), request.ProductName, request.ProductImageUrl, request.ProductUnitPrice, request.ProductQuantity);
        order.SetOrderAddress(request.AddressLine, request.City, request.Country, request.CityCode);
        await _orderRepository.AddAsync(order);
        await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        var mappedCustomer = _mapper.Map<GetOrderDto>(order);
        return new SuccessDataResult<GetOrderDto>(mappedCustomer);
    }
}