using MediatR;
using Tesodev.Case.Order.Application.Utilities.Results;
using Tesodev.Case.Order.Application.Dtos;

namespace Tesodev.Case.Order.Application.Queries;

public class GetOrdersQuery : IRequest<IDataResult<List<GetOrderDto>>>
{
}