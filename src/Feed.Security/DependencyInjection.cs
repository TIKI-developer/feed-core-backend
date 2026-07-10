using Feed.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Feed.Security;

public static class DependencyInjection
{
    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordHasher, BCryptHasher>();
        services.AddScoped<IAccessTokenService, AccessTokenService>();

        services.Configure<AccessTokenOptions>(options =>
        configuration.GetSection(nameof(AccessTokenOptions)).Bind(options));

        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<ITokenHasher, Sha256Hasher>();

        return services;
    }
}
