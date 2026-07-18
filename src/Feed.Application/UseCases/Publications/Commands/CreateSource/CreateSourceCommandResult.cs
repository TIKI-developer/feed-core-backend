using Mediator;

namespace Feed.Application.UseCases.Publications.Commands.CreateSource;

public readonly record struct CreateSourceCommandResult
{
    public required Guid Id { get; init; }
}
