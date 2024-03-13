using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tesodev.Case.Customer.API.Controllers.V1;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Application.Queries;
using Tesodev.Case.Customer.Application.Utilities.Results;

namespace Tesodev.Case.Customer.UnitTests.Application;

public class CustomerWebApiTest
{
    private readonly Mock<IMediator> _mediatorMock;
    public CustomerWebApiTest()
    {
        _mediatorMock = new Mock<IMediator>();
    }

    [Fact]
    public async Task Get_customers_success()
    {
        // Arrange
        _mediatorMock
            .Setup(x => x.Send(It.IsAny<GetCustomersQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SuccessResult<List<GetCustomerDto>>(new List<GetCustomerDto>()));

        // Act
        var customerController = new CustomerController(_mediatorMock.Object);
        var actionResult = await customerController.GetCustomers();

        // Assert
        Assert.IsType<OkObjectResult>(actionResult);
        var okObjectResult = (OkObjectResult)actionResult;
        Assert.Equal((int)System.Net.HttpStatusCode.OK, okObjectResult.StatusCode);
    }

    [Fact]
    public async Task Get_customer_by_id_success()
    {
        // Arrange
        _mediatorMock
            .Setup(x => x.Send(It.IsAny<GetCustomerByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SuccessResult<GetCustomerDto>(new GetCustomerDto()));

        // Act
        var customerController = new CustomerController(_mediatorMock.Object);
        var actionResult = await customerController.GetCustomerById(Guid.NewGuid().ToString());

        // Assert
        Assert.IsType<OkObjectResult>(actionResult);
        var okObjectResult = (OkObjectResult)actionResult;
        Assert.Equal((int)System.Net.HttpStatusCode.OK, okObjectResult.StatusCode);
    }
}