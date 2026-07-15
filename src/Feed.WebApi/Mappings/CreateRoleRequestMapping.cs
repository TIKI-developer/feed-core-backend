using Feed.Application.UseCases.Users.Commands.CreateRole;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class CreateRoleRequestMapping
{
    public static CreateRoleCommand ToCommand(this CreateRoleRequest request)
    {
        return new CreateRoleCommand
        {
            Name = request.Body.Name,
            Permissions = request.Body.Permissions
        };
    }
}
