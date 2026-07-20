using Feed.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Feed.Plugin.Host;

public static class DependencyInjection
{
    public static IServiceCollection AddPlugins(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PluginOptions>(options =>
        configuration.GetSection(nameof(PluginOptions)).Bind(options));
        services.AddSingleton<PluginLoader>();
        services.AddSingleton<ISourceProviderRegistry, SourceProviderRegistry>();

        return services;
    }
}
