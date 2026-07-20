using Feed.Domain.Shared.ValueObjects;

namespace Feed.WebApi.Responses;

public readonly record struct Response()
{
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}

public readonly record struct Response<T>(T Data)
{
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
