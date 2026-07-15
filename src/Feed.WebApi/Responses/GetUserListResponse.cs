using Feed.Application.ViewModels;

namespace Feed.WebApi.Responses;

public readonly record struct GetUserListResponse
{
    public required ICollection<UserItem> Users { get; init; }
}
