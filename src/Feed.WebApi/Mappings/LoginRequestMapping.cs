using Feed.Application.UseCases.Users.Commands.Login;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class LoginRequestMapping
{
    public static LoginCommand ToCommand(this LoginRequest request)
    {
        return new LoginCommand
        {
            Name = request.Name,
            Password = request.Password,
        };
    }
}
