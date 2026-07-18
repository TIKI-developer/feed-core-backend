using System.Reflection;
using System.Runtime.Loader;

namespace Feed.Plugin.Host;

internal sealed class PluginLoadContext : AssemblyLoadContext
{
    private readonly AssemblyDependencyResolver _resolver;

    public PluginLoadContext(string pluginPath)
        : base(isCollectible: false)
    {
        _resolver = new AssemblyDependencyResolver(pluginPath);
    }

    protected override Assembly? Load(AssemblyName assemblyName)
    {
        if (assemblyName.Name == "Feed.Plugin.Abstractions")
            return null;

        var path = _resolver.ResolveAssemblyToPath(assemblyName);

        if (path is not null)
            return LoadFromAssemblyPath(path);

        return null;
    }
}
