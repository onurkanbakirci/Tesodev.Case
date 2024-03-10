using MediatR;
using AutoMapper;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Application.Utilities.Results;
using Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;

namespace Tesodev.Case.Customer.Application.Queries.Handlers;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IResult<List<GetCustomerDto>>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public GetCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IResult<List<GetCustomerDto>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _customerRepository.GetAsync();

        var mappedOrders = _mapper.Map<List<GetCustomerDto>>(orders);

        return new SuccessResult<List<GetCustomerDto>>(mappedOrders);
    }
}