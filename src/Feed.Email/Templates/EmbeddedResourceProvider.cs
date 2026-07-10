namespace Feed.Email.Templates;

internal sealed class EmbeddedResourceProvider
{
    private readonly Dictionary<string, string> _cache = [];

    public string Get(string resource)
    {
        if (_cache.TryGetValue(resource, out var html))
            return html;

        var assembly = typeof(EmbeddedResourceProvider).Assembly;

        var fullName = assembly
            .GetManifestResourceNames()
            .Single(x => x.EndsWith(resource));

        using var stream = assembly.GetManifestResourceStream(fullName)!;
        using var reader = new StreamReader(stream);

        html = reader.ReadToEnd();

        _cache[resource] = html;

        return html;
    }
}
