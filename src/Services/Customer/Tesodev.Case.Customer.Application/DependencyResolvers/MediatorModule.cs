using System.Reflection;
using Autofac;
using FluentValidation;
using MediatR;
using Tesodev.Case.Customer.Application.Behaviors;
using Tesodev.Case.Customer.Application.Commands;
using Tesodev.Case.Customer.Application.Validations;

namespace Tesodev.Case.Customer.Application.DependencyResolvers;

public class MediatorModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
               .AsImplementedInterfaces();

        // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
        builder.RegisterAssemblyTypes(typeof(AddCustomerCommand).GetTypeInfo().Assembly)
               .AsClosedTypesOf(typeof(IRequestHandler<,>));


        builder.RegisterAssemblyTypes(typeof(AddCustomerCommandValidator).GetTypeInfo().Assembly)
               .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
               .AsImplementedInterfaces();

        builder.Register<ServiceFactory>(context =>
        {
            var componentContext = context.Resolve<IComponentContext>();
            return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
        });

        builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
    }
}