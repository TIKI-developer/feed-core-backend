using Feed.Application.UseCases.Users.Commands.Register;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class RegisterRequestMapping
{
    public static RegisterCommand ToCommand(this RegisterRequest request)
    {
        return new RegisterCommand
        {
            Name = request.Name,
            Password = request.Password
        };
    }
}