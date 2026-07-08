using Feed.Application.Exceptions;
using Feed.Application.Interfaces;
using Feed.Application.Mappings;
using Feed.Application.ViewModels;
using Feed.Domain.Users.Entities;
using Mediator;

namespace Feed.Application.UseCases.Users.Queries.GetUser;

internal sealed class GetUserQueryByIdHandler
    (IUserRepository userRepository)
    : IQueryHandler<GetUserByIdQuery, UserDetails>
{
    public async ValueTask<UserDetails> Handle(
        GetUserByIdQuery query,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(query.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(User), query.Id);

        return user.ToDetails();
    }
}
