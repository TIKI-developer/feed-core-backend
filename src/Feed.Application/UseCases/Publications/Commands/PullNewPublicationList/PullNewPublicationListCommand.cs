using Mediator;

namespace Feed.Application.UseCases.Publications.Commands.PullNewPublicationList;

public readonly record struct PullNewPublicationListCommand : ICommand<PullNewPublicationListCommandResult>
{
    public required Guid SourceId { get; init; }
}
