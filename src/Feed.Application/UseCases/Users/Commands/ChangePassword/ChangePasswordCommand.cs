using Mediator;

namespace Feed.Application.UseCases.Users.Commands.ChangePassword;

public readonly record struct ChangePasswordCommand : ICommand
{
    public required Guid Id { get; init; }
    public required string CurrentPassword { get; init; }
    public required string NewPassword { get; init; }
}
