using Feed.Domain.Users.Entities;

namespace Feed.Application.Interfaces.Repositories;

public interface IUserTokenRepository : IBaseRepository
{
    Task AddAsync(UserToken token, CancellationToken cancellationToken = default);
    Task<UserToken?> GetByTokenHashAsync(byte[] tokenHash, CancellationToken cancellationToken = default);
}
