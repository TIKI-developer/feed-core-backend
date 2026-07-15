using Mediator;

namespace Feed.Application.UseCases.Users.Queries.GetUserList;

public readonly record struct GetUserListQuery : IQuery<GetUserListQueryResult>
{
}
