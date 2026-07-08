using Feed.Application.ViewModels;
using Mediator;

namespace Feed.Application.UseCases.Users.Queries.GetUser;

public readonly record struct GetUserByIdQuery : IQuery<UserDetails>
{
    public required Guid Id { get; init; }
}
