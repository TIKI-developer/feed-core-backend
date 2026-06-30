using Feed.Domain.Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Feed.Security;

public static class DependencyInjection
{
    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IStringHasher, PasswordHasher>();
        services.AddScoped<IHashVerifier, PasswordHasher>();

        return services;
    }
}
