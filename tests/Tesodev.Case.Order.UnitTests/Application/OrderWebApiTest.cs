using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Moq;
using Tesodev.Case.Order.API.Controllers.V1;
using Tesodev.Case.Order.Application.Dtos;
using Tesodev.Case.Order.Application.Queries;
using Tesodev.Case.Order.Application.Utilities.Results;

namespace Tesodev.Case.Order.UnitTests.Application;

public class OrderWebApiTest
{
    private readonly Mock<IMediator> _mediatorMock;
    public OrderWebApiTest()
    {
        _mediatorMock = new Mock<IMediator>();
    }

    [Fact]
    public async Task Get_orders_success()
    {
        // Arrange
        _mediatorMock
            .Setup(x => x.Send(It.IsAny<GetOrdersQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SuccessDataResult<List<GetOrderDto>>(new List<GetOrderDto>()));

        // Act
        var orderController = new OrderController(_mediatorMock.Object);
        var actionResult = await orderController.GetOrders();

        // Assert
        Assert.IsType<OkObjectResult>(actionResult);
        var okObjectResult = (OkObjectResult)actionResult;
        Assert.Equal((int)System.Net.HttpStatusCode.OK, okObjectResult.StatusCode);
    }

    [Fact]
    public async Task Get_order_by_id_success()
    {
        // Arrange
        _mediatorMock
            .Setup(x => x.Send(It.IsAny<GetOrderByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SuccessDataResult<GetOrderDto>(new GetOrderDto()));

        // Act
        var orderController = new OrderController(_mediatorMock.Object);
        var actionResult = await orderController.GetOrderById(Guid.NewGuid().ToString());

        // Assert
        Assert.IsType<OkObjectResult>(actionResult);
        var okObjectResult = (OkObjectResult)actionResult;
        Assert.Equal((int)System.Net.HttpStatusCode.OK, okObjectResult.StatusCode);
    }
}