using Mediator;

namespace Feed.Application.UseCases.Publications.Commands.UpdateSource;

public readonly record struct UpdateSourceCommand : ICommand<Unit>
{
    public required Guid Id { get; init; }
    public string Name { get; init; }
}
