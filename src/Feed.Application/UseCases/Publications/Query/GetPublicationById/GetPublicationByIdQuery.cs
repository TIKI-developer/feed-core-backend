using Feed.Application.ViewModels;
using Mediator;

namespace Feed.Application.UseCases.Publications.Query.GetPublicationById;

public readonly record struct GetPublicationByIdQuery : IQuery<PublicationDetails>
{
    public required Guid Id { get; init; }
}
