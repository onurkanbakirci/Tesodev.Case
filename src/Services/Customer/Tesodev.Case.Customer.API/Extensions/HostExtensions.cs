using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Customer.Infrastructure;

namespace Tesodev.Case.Customer.API.Extensions;
public static class HostExtensions
{
    public static async Task<IHost> Seed(this IHost host)
    {
        var context = new CustomerContext()!;
        await context.Database.MigrateAsync();

        if (!context.Customers.Any())
        {
            var customer = new Domain.AggregatesModel.CustomerAggregate.Customer("John", "Doe");
            customer.SetCustomerAddress("Qatar,Doha", "Doha", "Qatar", 100);
            
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
        }
        return host;
    }
}