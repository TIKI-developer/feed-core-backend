using Feed.Domain.Users.ValueObjects;

namespace Feed.Application.Interfaces.Repositories;

public interface IPermissionRepository : IBaseRepository
{
    Task<ICollection<Permission>> GetAsync(CancellationToken cancellationToken);
}
