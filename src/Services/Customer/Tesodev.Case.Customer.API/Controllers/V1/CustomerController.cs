using System.Net;
using MediatR;
using Tesodev.Case.Customer.Application.Commands;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Application.Queries;
using Tesodev.Case.Customer.Application.Utilities.Results;

namespace Tesodev.Case.Customer.API.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/customers")]
public class CustomerController : Controller
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get customers
    /// </summary>
    /// <returns><see cref="Task{IActionResult}"/></returns>
    [HttpGet]
    [Produces("application/json", "text/plain")]
    [Consumes("application/json", "text/plain")]
    [ProducesResponseType(typeof(SuccessResult<List<GetCustomerDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetCustomers()
    {
        var commandResult = await _mediator.Send(new GetCustomersQuery());
        return Ok(commandResult);
    }

    /// <summary>
    /// Get customer by id
    /// </summary>
    /// <returns><see cref="Task{IActionResult}"/></returns>
    [HttpGet("{id}")]
    [Produces("application/json", "text/plain")]
    [Consumes("application/json", "text/plain")]
    [ProducesResponseType(typeof(SuccessResult<GetCustomerDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetCustomerById([FromRoute] string id)
    {
        var commandResult = await _mediator.Send(new GetCustomerByIdQuery(id));
        return Ok(commandResult);
    }

    /// <summary>
    /// Add customer
    /// </summary>
    /// <param name="addCustomerCommand">Add item command</param>
    /// <returns><see cref="Task{IActionResult}"/></returns>
    [HttpPost]
    [Produces("application/json", "text/plain")]
    [Consumes("application/json", "text/plain")]
    [ProducesResponseType(typeof(Result<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> AddCustomer([FromBody] AddCustomerCommand addCustomerCommand)
    {
        var commandResult = await _mediator.Send(addCustomerCommand);
        return CreatedAtAction(nameof(GetCustomers), commandResult);
    }

    /// <summary>
    /// Delete customer
    /// </summary>
    /// <returns><see cref="Task{IActionResult}"/></returns>
    [HttpDelete("{id}")]
    [Produces("application/json", "text/plain")]
    [Consumes("application/json", "text/plain")]
    [ProducesResponseType(typeof(Result<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteCustomer([FromRoute] string id)
    {
        var commandResult = await _mediator.Send(new DeleteCustomerCommand(id));
        return Ok(commandResult);
    }

    /// <summary>
    /// Update customer
    /// </summary>
    /// <returns><see cref="Task{IActionResult}"/></returns>
    [HttpPut("{id}")]
    [Produces("application/json", "text/plain")]
    [Consumes("application/json", "text/plain")]
    [ProducesResponseType(typeof(Result<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateCustomer([FromRoute] string id, [FromBody] UpdateCustomerCommand updateCustomerCommand)
    {
        updateCustomerCommand.CustomerId = id;
        var commandResult = await _mediator.Send(updateCustomerCommand);
        return Ok(commandResult);
    }
}