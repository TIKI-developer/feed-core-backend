using Mediator;

namespace Feed.Application.UseCases.Users.Commands.SendEmailConfirmation;

public readonly record struct SendEmailConfirmationCommand : ICommand
{
    public required Guid UserId { get; init; }
    public string NewEmail { get; init; }
    public string? ConfirmationUrlBase { get; init; }
}
