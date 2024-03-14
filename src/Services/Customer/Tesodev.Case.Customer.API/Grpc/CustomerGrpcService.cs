using AutoMapper;
using Grpc.Core;
using MediatR;
using Tesodev.Case.BuildingBlocks.Protos;
using Tesodev.Case.Customer.Application.Queries;

namespace Tesodev.Case.Customer.API.Grpc;

public class CustomerGrpcService : CustomerGrpc.CustomerGrpcBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public CustomerGrpcService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public override async Task<GetCustomerByIdGrpcResponse> GetCustomerById(GetCustomerByIdGrpcRequest request, ServerCallContext context)
    {
        var queryResult = await _mediator.Send(new GetCustomerByIdQuery(request.Id));
        var grpcResponse = _mapper.Map<GetCustomerByIdGrpcResponse>(queryResult.Data);
        return grpcResponse;
    }
}