using Feed.Domain.Users.Entities;

namespace Feed.Application.Interfaces;

public interface IUserRepository : IBaseRepository
{
    Task<ICollection<User>> GetAsync(CancellationToken cancellationToken = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task AddAsync(User user, CancellationToken cancellationToken = default);
}