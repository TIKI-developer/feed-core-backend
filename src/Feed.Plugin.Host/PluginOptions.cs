namespace Feed.Plugin.Host;

public sealed class PluginOptions
{
    public IReadOnlyList<string> Directories { get; init; } = [];
}
