using Mediator;

namespace Feed.Application.UseCases.Publications.Commands.PullNewPublicationList;

public readonly record struct PullNewPublicationListCommandResult
{
    public required ICollection<Guid> NewPublicationIds { get; init; }
}
