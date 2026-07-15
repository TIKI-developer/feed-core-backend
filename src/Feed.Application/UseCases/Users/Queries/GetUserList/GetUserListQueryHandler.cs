using Feed.Application.Interfaces.Repositories;
using Feed.Application.Mappings;
using Mediator;

namespace Feed.Application.UseCases.Users.Queries.GetUserList;

internal sealed class GetUserListQueryHandler
    (IUserRepository userRepository)
    : IQueryHandler<GetUserListQuery, GetUserListQueryResult>
{
    public async ValueTask<GetUserListQueryResult> Handle(
        GetUserListQuery query,
        CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAsync(cancellationToken);

        return new GetUserListQueryResult
        {
            Users = [.. users.Select(u => u.ToItem())]
        };
    }
}
