using WTelegram;

namespace Feed.Telegram;

internal sealed class TelegramClientFactory
{
    private readonly TelegramOptions _options;

    public TelegramClientFactory(TelegramOptions options)
    {
        _options = options;
    }

    public async Task<Client> CreateAsync()
    {
        var client = new Client(Config);

        await client.LoginUserIfNeeded();

        return client;
    }

    private string? Config(string what)
    {
        return what switch
        {
            "api_id" => _options.ApiId.ToString(),
            "api_hash" => _options.ApiHash,
            "phone_number" => _options.PhoneNumber,
            "session_pathname" => _options.SessionPath,
            _ => null
        };
    }
}
