using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Customer.Infrastructure;

namespace Tesodev.Case.Customer.API.Extensions;
public static class DbContextMiddlewareExtensions
{
    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services
                .AddDbContext<CustomerContext>(options =>
                {
                    options.UseNpgsql(
                                     connectionString: configuration.GetSection("DatabaseConfigurations:ConnectionString").Value,
                                     npgsqlOptionsAction: sqlOptions =>
                                     {
                                         sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                                     });
                }, ServiceLifetime.Scoped);

        return services;
    }
}

