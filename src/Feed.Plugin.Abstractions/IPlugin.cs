using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Feed.Plugin.Abstractions;

public interface IPlugin
{
    void ConfigureServices(
        IServiceCollection services,
        IConfiguration configuration);
}