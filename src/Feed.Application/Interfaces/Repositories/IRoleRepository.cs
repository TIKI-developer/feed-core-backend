using Feed.Domain.Users.Entities;

namespace Feed.Application.Interfaces.Repositories;

public interface IRoleRepository : IBaseRepository
{
    Task AddAsync(Role newRole, CancellationToken cancellationToken);
    Task<ICollection<Role>> GetAsync(CancellationToken cancellationToken);
}
