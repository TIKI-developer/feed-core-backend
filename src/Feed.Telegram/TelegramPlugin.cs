using Feed.Plugin.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WTelegram;

namespace Feed.Telegram;

public sealed class TelegramPlugin : IPlugin
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TelegramOptions>(
            configuration.GetRequiredSection("Telegram"));

        services.AddSingleton<Client>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<TelegramOptions>>().Value;
            return new TelegramClientFactory(options)
                .CreateAsync()
                .GetAwaiter()
                .GetResult();
        });

        services.AddSingleton<ISourceProvider, TelegramSourceProvider>();
    }
}
