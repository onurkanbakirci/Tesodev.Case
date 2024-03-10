using Autofac;
using Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;
using Tesodev.Case.Customer.Infrastructure.Repositories;

namespace Tesodev.Case.Customer.Application.DependencyResolvers;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
    }
}