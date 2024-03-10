using Autofac;
using Tesodev.Case.Order.Domain.AggregatesModel.OrderAggregate;
using Tesodev.Case.Order.Infrastructure.Repositories;

namespace Tesodev.Case.Order.Application.DependencyResolvers;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<OrderRepository>().As<IOrderRepository>();
    }
}