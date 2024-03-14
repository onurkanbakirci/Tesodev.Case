using AutoMapper;
using MediatR;
using Tesodev.Case.Customer.Application.Utilities.Results;
using Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;

namespace Tesodev.Case.Customer.Application.Commands.CommandHandlers;
public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, IResult>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(new Guid(request.CustomerId));
        _customerRepository.Delete(customer);
        await _customerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return new SuccessResult();
    }
}