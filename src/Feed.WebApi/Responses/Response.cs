using Feed.Domain.Shared.ValueObjects;

namespace Feed.WebApi.Responses;

public readonly record struct Response()
{
    public Timestamps Timestamps { get; init; } = Timestamps.Create();
}

public readonly record struct Response<T>(T Data)
{
    public Timestamps Timestamps { get; init; } = Timestamps.Create();
}