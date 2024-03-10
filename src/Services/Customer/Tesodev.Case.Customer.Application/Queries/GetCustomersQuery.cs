using MediatR;
using Tesodev.Case.Customer.Application.Utilities.Results;
using Tesodev.Case.Customer.Application.Dtos;

namespace Tesodev.Case.Customer.Application.Queries;

public class GetCustomersQuery : IRequest<IResult<List<GetCustomerDto>>>
{
}