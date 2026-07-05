using Feed.Application.Interfaces;
using Feed.Domain.Shared.Interfaces;
using Mediator;

namespace Feed.Application.UseCases.Users.Commands.Login;

internal sealed class LoginCommandHandler
    (IUserRepository userRepository,
    IHashVerifier hashVerifier,
    IAccessTokenService accessTokenService)
    : ICommandHandler<LoginCommand, LoginCommandResult>
{
    public async ValueTask<LoginCommandResult> Handle(
        LoginCommand command,
        CancellationToken cancellationToken)
    {
        var user = await userRepository
            .GetByNameAsync(command.Username, cancellationToken);

        if (user == null || !hashVerifier.Verify(command.Password, user.Password.Hash))
            throw new Exception("Invalid credentials");

        var accessToken = accessTokenService.Generate(user);

        return new() { AccessToken = accessToken };
    }
}