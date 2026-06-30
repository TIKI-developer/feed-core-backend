namespace Feed.Application.Interfaces;

internal interface IUserUniquenessChecker
{
    Task<bool> IsUniqueByName(string name, CancellationToken cancellationToken = default);
}
