using MediatR;
using AutoMapper;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Application.Utilities.Results;
using Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;

namespace Tesodev.Case.Customer.Application.Queries.Handlers;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, IDataResult<GetCustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<GetCustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(new Guid(request.Id));

        var mappedCustomer = _mapper.Map<GetCustomerDto>(customer);

        return new SuccessDataResult<GetCustomerDto>(mappedCustomer);
    }
}