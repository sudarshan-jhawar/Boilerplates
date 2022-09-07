using Infrastructure.Common.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure.Core;

public static class CommonExtensions
{
    public static IServiceCollection AddCommon(this IServiceCollection services)
    {
        services.AddScoped<ErrorHandlingMiddleware>();
        return services;
    }

    public static IApplicationBuilder UseCommon(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();
        return app;
    }
}
