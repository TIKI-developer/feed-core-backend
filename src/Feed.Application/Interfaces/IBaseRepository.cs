namespace Feed.Application.Interfaces;

public interface IBaseRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}