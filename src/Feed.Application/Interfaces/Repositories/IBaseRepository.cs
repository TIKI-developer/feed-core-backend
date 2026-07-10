namespace Feed.Application.Interfaces.Repositories;

public interface IBaseRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
