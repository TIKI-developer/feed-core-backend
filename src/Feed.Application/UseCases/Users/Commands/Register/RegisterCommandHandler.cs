using Feed.Application.Exceptions;
using Feed.Application.Interfaces;
using Feed.Domain.Shared.Interfaces;
using Feed.Domain.Shared.ValueObjects;
using Feed.Domain.Users.Entities;
using Mediator;

namespace Feed.Application.UseCases.Users.Commands.Register;

internal sealed class RegisterCommandHandler
    (IUserRepository userRepository,
    IUserUniquenessChecker userUniquenessChecker,
    IStringHasher stringHasher,
    IAccessTokenService accessTokenService)
    :
    ICommandHandler<RegisterCommand, RegisterCommandResult>
{
    public async ValueTask<RegisterCommandResult>
        Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (!await userUniquenessChecker.IsUniqueByName(command.Name, cancellationToken))
        {
            throw new AlreadyExist(nameof(User), command.Name);
        }

        var newUser = User.Create(command.Name, Password.Create(command.Password, stringHasher));
        var accessToken = accessTokenService.Generate(newUser);

        await userRepository.AddAsync(newUser, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);

        return new RegisterCommandResult { AccessToken = accessToken };
    }
}
