using Feed.Application.Interfaces.Repositories;
using Feed.Application.Mappings;
using Mediator;

namespace Feed.Application.UseCases.Users.Queries.GetRoleList
{
    internal sealed class GetRoleListQueryHandler
        (IRoleRepository roleRepository)
        : IQueryHandler<GetRoleListQuery, GetRoleListQueryResult>
    {
        public async ValueTask<GetRoleListQueryResult> Handle(
            GetRoleListQuery query,
            CancellationToken cancellationToken)
        {
            var roles = await roleRepository.GetAsync(cancellationToken);

            return new GetRoleListQueryResult
            {
                Roles = [.. roles.Select(r => r.ToItem())]
            };
        }
    }
}
