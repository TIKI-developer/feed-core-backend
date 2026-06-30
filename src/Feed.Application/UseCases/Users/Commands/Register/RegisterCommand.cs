using Mediator;

namespace Feed.Application.UseCases.Users.Commands.Register;

public readonly record struct RegisterCommand : ICommand<RegisterCommandResult>
{
    public required string Name { get; init; }
    public required string Password { get; init; }
}
