using Mediator;

namespace Feed.Application.UseCases.Users.Commands.CreateRole;

public readonly record struct CreateRoleCommand : ICommand
{
    public required string Name { get; init; }
    public required ICollection<string> Permissions { get; init; }
}
