using AutoMapper;
using MediatR;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Application.Utilities.Results;
using Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;

namespace Tesodev.Case.Customer.Application.Commands.CommandHandlers;
public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, IResult<GetCustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public AddCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IResult<GetCustomerDto>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Domain.AggregatesModel.CustomerAggregate.Customer(request.Name, request.Email);
        customer.SetCustomerAddress(request.AddressLine, request.City, request.Country, request.CityCode);
        await _customerRepository.AddAsync(customer);
        await _customerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        var mappedCustomer = _mapper.Map<GetCustomerDto>(customer);
        return new SuccessResult<GetCustomerDto>(mappedCustomer);
    }
}