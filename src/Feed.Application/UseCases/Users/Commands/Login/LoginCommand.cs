using Mediator;

namespace Feed.Application.UseCases.Users.Commands.Login;

public readonly record struct LoginCommand : ICommand<LoginCommandResult>
{
    public required string Name { get; init; }
    public required string Password { get; init; }
}
