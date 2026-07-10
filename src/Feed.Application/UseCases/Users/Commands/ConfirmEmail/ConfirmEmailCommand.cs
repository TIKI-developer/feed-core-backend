using Mediator;

namespace Feed.Application.UseCases.Users.Commands.ConfirmEmail
{
    public readonly record struct ConfirmEmailCommand : ICommand
    {
        public readonly Guid UserId { get; init; }
        public readonly string Token { get; init; }
        public readonly string NewEmail { get; init; }
    }
}
