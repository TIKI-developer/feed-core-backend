using Mediator;

namespace Feed.Application.UseCases.Users.Commands.Login;

public readonly record struct LoginCommandResult
{
    public required string AccessToken { get; init; }
}
