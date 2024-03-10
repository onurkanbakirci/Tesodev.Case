using Tesodev.Case.Customer.Application.Middlewares;

namespace Tesodev.Case.Customer.API.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
