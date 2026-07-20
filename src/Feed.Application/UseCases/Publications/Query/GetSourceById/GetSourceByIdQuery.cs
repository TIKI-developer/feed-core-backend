using Feed.Application.ViewModels;
using Mediator;

namespace Feed.Application.UseCases.Publications.Query.GetSourceById;

public readonly record struct GetSourceByIdQuery : IQuery<SourceDetails>
{
    public required Guid Id { get; init; }
}
