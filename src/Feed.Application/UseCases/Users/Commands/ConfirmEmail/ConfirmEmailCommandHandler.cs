using Feed.Application.Exceptions;
using Feed.Application.Interfaces;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Shared.ValueObjects;
using Feed.Domain.Users.Entities;
using Mediator;

namespace Feed.Application.UseCases.Users.Commands.ConfirmEmail
{
    internal sealed class ConfirmEmailCommandHandler
        (IUserTokenRepository userTokenRepository,
        IUserRepository userRepository,
        ITokenHasher tokenHasher)
        : ICommandHandler<ConfirmEmailCommand>
    {
        public async ValueTask<Unit> Handle(
            ConfirmEmailCommand command,
            CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(command.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), command.UserId);

            var token = await userTokenRepository.GetByTokenHashAsync(tokenHasher.Hash(command.Token), cancellationToken)
                ?? throw new NotFoundException(nameof(UserToken), command.Token);

            if (token.ExpiredAt < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Token has expired.");
            }

            if (token.Purpose is not UserTokenPurpose.EmailConfirmation)
            {
                throw new InvalidOperationException("Invalid token purpose.");
            }

            user.ChangeEmail(Email.Create(command.NewEmail));
            await userRepository.UpdateAsync(user, cancellationToken);

            await userRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
