using System.Net;
using MediatR;
using Tesodev.Case.Order.Application.Commands;
using Tesodev.Case.Order.Application.Dtos;
using Tesodev.Case.Order.Application.Queries;
using Tesodev.Case.Order.Application.Utilities.Results;

namespace Tesodev.Case.Order.API.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/orders")]
public class OrderController : Controller
{
    private readonly IMediator _mediator;
    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get orders
    /// </summary>
    /// <returns><see cref="Task{IActionResult}"/></returns>
    [HttpGet]
    [Produces("application/json", "text/plain")]
    [Consumes("application/json", "text/plain")]
    [ProducesResponseType(typeof(SuccessDataResult<List<GetOrderDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetOrders()
    {
        var commandResult = await _mediator.Send(new GetOrdersQuery());
        return Ok(commandResult);
    }

    /// <summary>
    /// Get order by id
    /// </summary>
    /// <returns><see cref="Task{IActionResult}"/></returns>
    [HttpGet("{id}")]
    [Produces("application/json", "text/plain")]
    [Consumes("application/json", "text/plain")]
    [ProducesResponseType(typeof(SuccessDataResult<GetOrderDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetOrderById([FromRoute] string id)
    {
        var commandResult = await _mediator.Send(new GetOrderByIdQuery(id));
        return Ok(commandResult);
    }

    /// <summary>
    /// Add order
    /// </summary>
    /// <param name="addOrderCommand">Add item command</param>
    /// <returns><see cref="Task{IActionResult}"/></returns>
    [HttpPost]
    [Produces("application/json", "text/plain")]
    [Consumes("application/json", "text/plain")]
    [ProducesResponseType(typeof(SuccessDataResult<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> AddOrder([FromBody] AddOrderCommand addOrderCommand)
    {
        var commandResult = await _mediator.Send(addOrderCommand);
        return CreatedAtAction(nameof(GetOrders), commandResult);
    }

    /// <summary>
    /// Delete order
    /// </summary>
    /// <returns><see cref="Task{IActionResult}"/></returns>
    [HttpDelete("{id}")]
    [Produces("application/json", "text/plain")]
    [Consumes("application/json", "text/plain")]
    [ProducesResponseType(typeof(SuccessResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteOrder([FromRoute] string id)
    {
        var commandResult = await _mediator.Send(new DeleteOrderCommand(id));
        return Ok(commandResult);
    }

    /// <summary>
    /// Update order
    /// </summary>
    /// <returns><see cref="Task{IActionResult}"/></returns>
    [HttpPut("{id}")]
    [Produces("application/json", "text/plain")]
    [Consumes("application/json", "text/plain")]
    [ProducesResponseType(typeof(SuccessDataResult<GetOrderDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateOrder([FromRoute] string id, [FromBody] UpdateOrderCommand updateOrderCommand)
    {
        updateOrderCommand.OrderId = id;
        var commandResult = await _mediator.Send(updateOrderCommand);
        return Ok(commandResult);
    }
}