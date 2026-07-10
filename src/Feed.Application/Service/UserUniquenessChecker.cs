using Feed.Application.Interfaces;
using Feed.Application.Interfaces.Repositories;

namespace Feed.Application.Service;

public class UserUniquenessChecker(IUserRepository userRepository) : IUserUniquenessChecker
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<bool> IsUniqueByName(string name, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByNameAsync(name, cancellationToken) == null;
    }
}
