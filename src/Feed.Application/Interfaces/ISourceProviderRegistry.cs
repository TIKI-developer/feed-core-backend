using Feed.Plugin.Abstractions;

namespace Feed.Application.Interfaces;

public interface ISourceProviderRegistry
{
    IReadOnlyCollection<ISourceProvider> GetAll();
    ISourceProvider? Get(string name);
}
