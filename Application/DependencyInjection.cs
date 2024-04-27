using Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var dependencyInjectionAssembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(dependencyInjectionAssembly));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValisationPiplineBehavior<,>));

        services.AddValidatorsFromAssembly(dependencyInjectionAssembly, includeInternalTypes: true);

        services.AddAutoMapper(dependencyInjectionAssembly);

        return services;
    }
}
