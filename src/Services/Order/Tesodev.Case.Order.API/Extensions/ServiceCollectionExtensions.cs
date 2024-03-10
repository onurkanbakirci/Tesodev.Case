namespace Tesodev.Case.Order.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules, IConfiguration configuration)
    {
        foreach (var module in modules)
        {
            module.Load(services, configuration);
        }

        return ServiceTool.Create(services);
    }
}