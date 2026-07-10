using Feed.Application.UseCases.Users.Commands.SendEmailConfirmation;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class SendEmailConfirmationMapping
{
    public static SendEmailConfirmationCommand ToCommand(this SendEmailConfirmationRequest request, Guid userId, string? confirmationUrlBase )
    {
        return new SendEmailConfirmationCommand
        {
            UserId = userId,
            NewEmail = request.Body.Email,
            ConfirmationUrlBase = confirmationUrlBase
        };
    }
}
