using Feed.Application.ViewModels;
using Mediator;

namespace Feed.Application.UseCases.Users.Queries.GetUserList;

public readonly record struct GetUserListQueryResult
{
    public required ICollection<UserItem> Users { get; init; }
}
