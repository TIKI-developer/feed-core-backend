using Feed.Application.UseCases.Users.Commands.ChangePassword;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class ChangePasswordRequestMapping
{
    public static ChangePasswordCommand ToCommand(this ChangePasswordRequest request, Guid userId)
    {
        return new ChangePasswordCommand
        {
            Id = userId,
            CurrentPassword = request.Body.CurrentPassword,
            NewPassword = request.Body.NewPassword
        };
    }
}
