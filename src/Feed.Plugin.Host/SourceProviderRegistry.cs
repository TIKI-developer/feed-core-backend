using Feed.Application.Interfaces;
using Feed.Plugin.Abstractions;
using System.Xml.Linq;

namespace Feed.Plugin.Host;

internal sealed class SourceProviderRegistry : ISourceProviderRegistry
{
    private readonly IReadOnlyCollection<ISourceProvider> _providers;
    private readonly IReadOnlyDictionary<string, ISourceProvider> _lookup;

    public SourceProviderRegistry(PluginLoader pluginLoader)
    {
        _providers = [.. pluginLoader.Load()];

        _lookup = _providers.ToDictionary(
            p => p.Name,
            StringComparer.OrdinalIgnoreCase);
    }

    public ISourceProvider? Get(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        Console.WriteLine(name);

        return _lookup.GetValueOrDefault(name);
    }

    public IReadOnlyCollection<ISourceProvider> GetAll()
    {
        return _providers;
    }
}
