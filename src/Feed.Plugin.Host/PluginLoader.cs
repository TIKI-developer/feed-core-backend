using Feed.Plugin.Abstractions;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Feed.Plugin.Host;

internal sealed class PluginLoader(IOptions<PluginOptions> options)
{
    public IReadOnlyCollection<ISourceProvider> Load()
    {
        var providers = new List<ISourceProvider>();

        foreach (var directory in options.Value.Directories)
        {
            LoadDirectory(directory, providers);
        }

        return providers;
    }

    private static void LoadDirectory(
        string root,
        ICollection<ISourceProvider> providers)
    {
        Console.WriteLine($"Scanning: {root}");
        Console.WriteLine($"Exists: {Directory.Exists(root)}");

        if (!Directory.Exists(root))
            return;

        foreach (var pluginDirectory in Directory.EnumerateDirectories(root))
        {
            var pluginName = Path.GetFileName(pluginDirectory);

            var dll = Path.Combine(pluginDirectory, $"{pluginName}.dll");

            Console.WriteLine(dll);
            Console.WriteLine(File.Exists(dll));

            if (!File.Exists(dll))
                continue;

            var loadContext = new PluginLoadContext(dll);
            var assembly = loadContext.LoadFromAssemblyPath(Path.GetFullPath(dll));
            Console.WriteLine(assembly.FullName);

            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine(type.FullName);
                Console.WriteLine(typeof(ISourceProvider).IsAssignableFrom(type));

                if (!typeof(ISourceProvider).IsAssignableFrom(type))
                    continue;

                if (type.IsInterface || type.IsAbstract)
                    continue;

                if (Activator.CreateInstance(type) is ISourceProvider provider)
                    providers.Add(provider);

                Console.WriteLine(type.FullName);
            }
        }
    }
}
