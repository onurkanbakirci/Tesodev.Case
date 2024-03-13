using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Order.Infrastructure;

namespace Tesodev.Case.Order.API.Extensions;
public static class HostExtensions
{
    public static async Task<IHost> Seed(this IHost host)
    {
        var context = new OrderContext();
        await context.Database.MigrateAsync();

        if (!context.Orders.Any())
        {
            var order = new Domain.AggregatesModel.OrderAggregate.Order(Guid.NewGuid());
            order
                .SetOrderProduct(Guid.NewGuid(), "Macbook Air", "https://google.com", 100, 1)
                .SetOrderAddress("Qatar,Doha", "Doha", "Qatar", 100);

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }
        return host;
    }
}