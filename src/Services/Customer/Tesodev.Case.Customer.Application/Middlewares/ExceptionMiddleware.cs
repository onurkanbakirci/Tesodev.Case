using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Tesodev.Case.Customer.Application.CrossCuttingConcerns.Logging;

namespace Tesodev.Case.Customer.Application.Middlewares;

public class ExceptionMiddleware
{
    private RequestDelegate _next;
    private readonly IHttpContextAccessor? _httpContextAccessor;

    public ExceptionMiddleware(RequestDelegate next, IHttpContextAccessor? httpContextAccessor)
    {
        _next = next;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(httpContext, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        LogError(exception);

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        return httpContext.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = exception.Message
        }.ToString());
    }

    private void LogError(Exception exception)
    {
        var logParameters = new List<LogParameter>();
        logParameters.Add(new LogParameter
        {
            // Exception type
            Name = "Exception",
            Value = exception.StackTrace,
            Type = exception.Message
        });

        if (exception.InnerException != null)
        {
            logParameters.Add(new LogParameter
            {
                // Inner exception type
                Name = "InnerException",
                Value = exception.InnerException.StackTrace,
                Type = exception.InnerException.Message
            });
        }
        var logDetail = new LogDetail
        {
            // get the method name from the stack trace between at and (
            MethodName = exception.StackTrace?.Substring(exception.StackTrace.IndexOf("at", StringComparison.Ordinal) + 3,
                exception.StackTrace.IndexOf("(", StringComparison.Ordinal) - exception.StackTrace.IndexOf("at", StringComparison.Ordinal) - 3),
            LogParameters = logParameters,
            User = (_httpContextAccessor?.HttpContext == null ||
                    _httpContextAccessor?.HttpContext?.User?.Identity?.Name == null)
                ? "?"
                : _httpContextAccessor.HttpContext.User.Identity.Name!
        };
        Console.WriteLine(JsonConvert.SerializeObject(logDetail));
    }
}

