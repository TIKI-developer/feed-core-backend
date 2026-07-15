using Feed.Application.Exceptions;
using Feed.Application.Interfaces;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Shared.ValueObjects;
using Feed.Domain.Users.Entities;
using Mediator;

namespace Feed.Application.UseCases.Users.Commands.ChangePassword;

internal sealed class ChangePasswordCommandHandler
    (IUserRepository userRepository,
    IPasswordHasher passwordHasher)
    : ICommandHandler<ChangePasswordCommand>
{
    public async ValueTask<Unit> Handle(
        ChangePasswordCommand command,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(User), command.Id);

        if (!passwordHasher.Verify(command.CurrentPassword, user.Password.Hash))
            throw new InvalidOperationException("Current password is incorrect.");

        user.ChangePassword(Password.Create(passwordHasher.Hash(command.NewPassword)));
        await userRepository.UpdateAsync(user, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
