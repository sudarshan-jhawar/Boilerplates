using Infrastructure.Core.Commands;
using Infrastructure.Core.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Core;

public static class CoreExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, params Type[] types)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<ICommandBus, CommandBus>();
        services.AddScoped<IQueryBus, QueryBus>();
        services.AddScoped<IEventBus, EventBus>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddOptions();
        return services;
    }
}
