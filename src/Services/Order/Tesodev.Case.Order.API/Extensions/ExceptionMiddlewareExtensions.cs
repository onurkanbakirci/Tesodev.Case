using Tesodev.Case.Order.Application.Middlewares;

namespace Tesodev.Case.Order.API.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
