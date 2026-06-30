using Feed.Application.Common;
using Feed.Application.Interfaces;
using Feed.Application.Service;
using FluentValidation;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Feed.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CurrentAssemblyMarker>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });

        services.AddScoped<IUserUniquenessChecker, UserUniquenessChecker>();

        return services;
    }
}
