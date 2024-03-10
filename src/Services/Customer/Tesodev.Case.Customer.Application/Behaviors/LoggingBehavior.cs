using MediatR;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Tesodev.Case.Customer.Infrastructure.Utilities.IoC;
using Tesodev.Case.Customer.Application.CrossCuttingConcerns.Logging;

namespace Tesodev.Case.Customer.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IHttpContextAccessor? _httpContextAccessor;
    public LoggingBehavior()
    {
        _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        List<LogParameter> logParameters = new();

        logParameters.Add(new LogParameter
        {
            Type = request.GetType().Name,
            Value = request
        });

        var logDetail = new LogDetail()
        {
            MethodName = next.Method.Name,
            LogParameters = logParameters,
            User = _httpContextAccessor?.HttpContext == null ||
                   _httpContextAccessor?.HttpContext?.User?.Identity?.Name == null
                ? "?"
                : _httpContextAccessor.HttpContext.User.Identity.Name!

        };
        Console.WriteLine(JsonConvert.SerializeObject(logDetail));
        //_loggerServiceBase.Info(JsonConvert.SerializeObject(logDetail));
        return next();
    }
}