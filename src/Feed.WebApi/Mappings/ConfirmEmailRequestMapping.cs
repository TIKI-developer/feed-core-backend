using Feed.Application.UseCases.Users.Commands.ConfirmEmail;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class ConfirmEmailRequestMapping
{
    public static ConfirmEmailCommand ToCommand(this ConfirmEmailChangingRequest request, Guid userId)
    {
        return new ConfirmEmailCommand 
        {
            UserId = userId,
            Token = request.Token,
            NewEmail = request.NewEmail
        };
    }
}
