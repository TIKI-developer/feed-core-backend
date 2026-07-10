using Feed.Application.Interfaces;
using Feed.Application.Interfaces.Repositories;
using Mediator;

namespace Feed.Application.UseCases.Users.Commands.Login;

internal sealed class LoginCommandHandler
    (IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IAccessTokenService accessTokenService)
    : ICommandHandler<LoginCommand, LoginCommandResult>
{
    public async ValueTask<LoginCommandResult> Handle(
        LoginCommand command,
        CancellationToken cancellationToken)
    {
        var user = await userRepository
            .GetByNameAsync(command.Name, cancellationToken);

        if (user == null || !passwordHasher.Verify(command.Password, user.Password.Hash))
            throw new Exception("Invalid credentials");

        var accessToken = accessTokenService.Generate(user);

        return new() { AccessToken = accessToken };
    }
}