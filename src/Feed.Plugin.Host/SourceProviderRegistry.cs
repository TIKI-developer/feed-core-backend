using Feed.Application.Interfaces;
using Feed.Plugin.Abstractions;
using Microsoft.Extensions.Logging;

namespace Feed.Plugin.Host;

internal sealed class SourceProviderRegistry : ISourceProviderRegistry
{
    private readonly IReadOnlyCollection<ISourceProvider> _providers;
    private readonly IReadOnlyDictionary<string, ISourceProvider> _lookup;

    public SourceProviderRegistry(
        IEnumerable<ISourceProvider> providers,
        ILogger<SourceProviderRegistry> logger)
    {
        _providers = providers.ToArray();

        var lookup = new Dictionary<string, ISourceProvider>(StringComparer.OrdinalIgnoreCase);

        foreach (var provider in _providers)
        {
            if (!lookup.TryAdd(provider.Name, provider))
            {
                logger.LogWarning(
                    "Duplicate source provider name '{Name}' detected. Only the first one will be used.",
                    provider.Name);
            }
        }

        _lookup = lookup;
    }

    public ISourceProvider? Get(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return _lookup.GetValueOrDefault(name);
    }

    public IReadOnlyCollection<ISourceProvider> GetAll()
        => _providers;
}
