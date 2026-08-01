namespace Feed.Telegram;

public sealed class TelegramOptions
{
    public required int ApiId { get; init; }

    public required string ApiHash { get; init; }

    public required string PhoneNumber { get; init; }

    public required string SessionPath { get; init; }
}
