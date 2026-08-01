using Feed.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Feed.Plugin.Host;

public static class DependencyInjection
{
    public static IServiceCollection AddPlugins(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<PluginOptions>(
            configuration.GetSection("PluginOptions"));

        var options = configuration
            .GetRequiredSection("PluginOptions")
            .Get<PluginOptions>()!;

        PluginLoader.ConfigureServices(services, configuration, options);

        services.AddSingleton<ISourceProviderRegistry, SourceProviderRegistry>();

        return services;
    }
}