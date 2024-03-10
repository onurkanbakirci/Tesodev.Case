using Tesodev.Case.Customer.Infrastructure.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace Tesodev.Case.Customer.Application.DependencyResolvers;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}