using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tesodev.Case.Customer.Infrastructure.Utilities.IoC;

public interface ICoreModule
{
    void Load(IServiceCollection collection, IConfiguration configuration);
}