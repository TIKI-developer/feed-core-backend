using DotNetEnv;

namespace Feed.WebApi.Configuration;

internal static class EnvFileLoader
{
    public static void Load()
    {
        foreach (var fileName in GetCandidateFiles())
        {
            var path = FindFile(fileName);

            if (path is null)
                continue;

            Env.Load(path, new LoadOptions(clobberExistingVars: false));
        }
    }

    private static IEnumerable<string> GetCandidateFiles()
    {
        yield return ".env";

        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        if (string.Equals(environment, Environments.Development, StringComparison.OrdinalIgnoreCase))
            yield return "dev.env";
        else if (string.Equals(environment, Environments.Production, StringComparison.OrdinalIgnoreCase))
            yield return "prod.env";
    }

    private static string? FindFile(string fileName)
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (directory is not null)
        {
            var path = Path.Combine(directory.FullName, fileName);

            if (File.Exists(path))
                return path;

            directory = directory.Parent;
        }

        return null;
    }
}