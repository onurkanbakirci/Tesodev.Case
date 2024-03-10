using MediatR;
using Tesodev.Case.Order.Application.Utilities.Results;
using Tesodev.Case.Order.Application.Dtos;

namespace Tesodev.Case.Order.Application.Queries;

public class GetOrderByIdQuery : IRequest<IResult<GetOrderDto>>
{
    public string Id { get; set; }
    public GetOrderByIdQuery(string id)
    {
        Id = id;
    }
}