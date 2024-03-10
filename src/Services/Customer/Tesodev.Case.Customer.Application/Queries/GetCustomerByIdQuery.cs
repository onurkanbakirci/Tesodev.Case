using MediatR;
using Tesodev.Case.Customer.Application.Utilities.Results;
using Tesodev.Case.Customer.Application.Dtos;

namespace Tesodev.Case.Customer.Application.Queries;

public class GetCustomerByIdQuery : IRequest<IResult<GetCustomerDto>>
{
    public string Id { get; set; }
    public GetCustomerByIdQuery(string id)
    {
        Id = id;
    }
}