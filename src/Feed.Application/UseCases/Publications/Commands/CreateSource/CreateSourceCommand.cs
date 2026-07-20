using Mediator;

namespace Feed.Application.UseCases.Publications.Commands.CreateSource;

public readonly record struct CreateSourceCommand : ICommand<CreateSourceCommandResult>
{
    public required string Name { get; init; }
    public required string ExternalId { get; init; }
    public required string SourceProviderName { get; init; }
}
