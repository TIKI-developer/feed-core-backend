using Feed.Plugin.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Feed.Plugin.Host;

internal sealed class PluginLoader(IOptions<PluginOptions> options, ILogger<PluginLoader> logger)
{
    public IReadOnlyCollection<ISourceProvider> Load()
    {
        var providers = new List<ISourceProvider>();

        foreach (var directory in options.Value.Directories)
        {
            LoadDirectory(directory, providers);
        }

        logger.LogInformation("Loaded {Count} source provider(s) from {DirectoryCount} directory(ies)",
            providers.Count, options.Value.Directories.Count);

        return providers;
    }

    private void LoadDirectory(
        string root,
        ICollection<ISourceProvider> providers)
    {
        if (!Directory.Exists(root))
        {
            logger.LogWarning("Plugin directory {Root} does not exist, skipping", root);
            return;
        }

        foreach (var pluginDirectory in Directory.EnumerateDirectories(root))
        {
            var pluginName = Path.GetFileName(pluginDirectory);
            var dll = Path.Combine(pluginDirectory, $"{pluginName}.dll");

            if (!File.Exists(dll))
            {
                logger.LogWarning(
                    "Expected {Dll} for plugin {PluginName}, but the file was not found. Skipping",
                    dll, pluginName);
                continue;
            }

            Assembly assembly;

            try
            {
                var loadContext = new PluginLoadContext(dll);
                assembly = loadContext.LoadFromAssemblyPath(Path.GetFullPath(dll));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to load assembly for plugin {PluginName} from {Dll}", pluginName, dll);
                continue;
            }

            foreach (var type in assembly.GetTypes())
            {
                if (type.IsInterface || type.IsAbstract)
                    continue;

                if (!typeof(ISourceProvider).IsAssignableFrom(type))
                    continue;

                try
                {
                    if (Activator.CreateInstance(type) is ISourceProvider provider)
                    {
                        providers.Add(provider);
                        logger.LogInformation("Loaded source provider {ProviderName} ({Type}) from {PluginName}",
                            provider.Name, type.FullName, pluginName);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Failed to instantiate {Type} from plugin {PluginName}",
                        type.FullName, pluginName);
                }
            }
        }
    }
}
