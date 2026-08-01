using Feed.Plugin.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Feed.Plugin.Host;

internal static class PluginLoader
{
    public static void ConfigureServices(
        IServiceCollection services,
        IConfiguration configuration,
        PluginOptions options)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(options);

        foreach (var directory in options.Directories)
        {
            ConfigureDirectory(services, configuration, directory);
        }
    }

    private static void ConfigureDirectory(
        IServiceCollection services,
        IConfiguration configuration,
        string root)
    {
        if (!Directory.Exists(root))
            return;

        foreach (var pluginDirectory in Directory.EnumerateDirectories(root))
        {
            var pluginName = Path.GetFileName(pluginDirectory);
            var dll = Path.Combine(pluginDirectory, $"{pluginName}.dll");

            if (!File.Exists(dll))
                continue;

            Assembly assembly;

            try
            {
                var loadContext = new PluginLoadContext(dll);
                assembly = loadContext.LoadFromAssemblyPath(Path.GetFullPath(dll));
            }
            catch
            {
                // Можно накопить ошибки и вывести позже,
                // либо просто пропустить плагин.
                continue;
            }

            ConfigureAssembly(services, configuration, assembly);
        }
    }

    private static void ConfigureAssembly(
        IServiceCollection services,
        IConfiguration configuration,
        Assembly assembly)
    {
        foreach (var type in assembly.GetExportedTypes())
        {
            if (type.IsAbstract || type.IsInterface)
                continue;

            if (!typeof(IPlugin).IsAssignableFrom(type))
                continue;

            var plugin = (IPlugin)Activator.CreateInstance(type)!;

            plugin.ConfigureServices(services, configuration);
        }
    }
}
