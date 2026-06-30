using Feed.Application.UseCases.Users.Commands.Register;
using Feed.WebApi.Responses;

namespace Feed.WebApi.Mappings;

public static class RegisterResponseMapping
{
    public static RegisterResponse ToResponse(this RegisterCommandResult result)
    {
        return new RegisterResponse
        {
        };
    }
}