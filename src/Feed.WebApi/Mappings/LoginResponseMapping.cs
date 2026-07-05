using Feed.Application.UseCases.Users.Commands.Login;
using Feed.WebApi.Responses;

namespace Feed.WebApi.Mappings;

public static class LoginResponseMapping
{
    public static LoginResponse ToResponse(this LoginCommandResult request)
    {
        return new LoginResponse
        {
            AccessToken = request.AccessToken,
        };
    }
}
