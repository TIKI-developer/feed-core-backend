using Feed.Application.Interfaces;
using Feed.Application.Interfaces.Messages;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Users.Entities;
using Mediator;

namespace Feed.Application.UseCases.Users.Commands.SendEmailConfirmation;

internal sealed class SendEmailConfirmationCommandHandler
    (IEmailService emailService,
    ITokenHasher tokenHasher,
    IConfirmationUrlProvider confirmationUrlProvider,
    ITokenGenerator tokenGenerator,
    IUserTokenRepository tokenRepository)
    : ICommandHandler<SendEmailConfirmationCommand, Unit>
{
    public async ValueTask<Unit> Handle(
        SendEmailConfirmationCommand command,
        CancellationToken cancellationToken)
    {
        var tokenPlain = tokenGenerator.Generate(48);

        var confirmationToken = UserToken.Create(
            command.UserId,
            tokenHasher.Hash(tokenPlain),
            DateTime.UtcNow.AddHours(24),
            UserTokenPurpose.EmailConfirmation
        );

        await tokenRepository.AddAsync(confirmationToken, cancellationToken);
        await tokenRepository.SaveChangesAsync(cancellationToken);

        var confirmationUri = confirmationUrlProvider.BuildConfirmationUrl(command.ConfirmationUrlBase, tokenPlain, command.NewEmail);

        await emailService.SendAsync(
            command.NewEmail,
            new ConfirmEmailMessage(confirmationUri)
        );

        return Unit.Value;
    }
}
