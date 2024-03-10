using MediatR;
using AutoMapper;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Application.Utilities.Results;
using Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;

namespace Tesodev.Case.Customer.Application.Queries.Handlers;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, IResult<GetCustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IResult<GetCustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _customerRepository.GetByIdAsync(new Guid(request.Id));

        var mappedOrder = _mapper.Map<GetCustomerDto>(order);

        return new SuccessResult<GetCustomerDto>(mappedOrder);
    }
}