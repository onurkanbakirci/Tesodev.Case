using AutoMapper;
using MediatR;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Application.Utilities.Results;
using Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;

namespace Tesodev.Case.Customer.Application.Commands.CommandHandlers;
public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, IResult<GetCustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IResult<GetCustomerDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(new Guid(request.CustomerId));
        _mapper.Map(request, customer);
        _customerRepository.Update(customer);
        await _customerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        var mappedCustomer = _mapper.Map<GetCustomerDto>(customer);
        return new SuccessResult<GetCustomerDto>(mappedCustomer);
    }
}