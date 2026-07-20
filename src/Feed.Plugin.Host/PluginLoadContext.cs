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
        var alreadyLoadedByHost = AssemblyLoadContext.Default.Assemblies
            .Any(a => string.Equals(a.GetName().Name, assemblyName.Name, StringComparison.Ordinal));

        if (alreadyLoadedByHost)
            return null;

        var path = _resolver.ResolveAssemblyToPath(assemblyName);

        return path is not null
            ? LoadFromAssemblyPath(path)
            : null;
    }
}
