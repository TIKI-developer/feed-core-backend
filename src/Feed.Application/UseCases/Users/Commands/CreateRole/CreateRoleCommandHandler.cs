using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Users.Entities;
using Feed.Domain.Users.ValueObjects;
using Mediator;

namespace Feed.Application.UseCases.Users.Commands.CreateRole;

internal sealed class CreateRoleCommandHandler
    (IRoleRepository roleRepository,
    IPermissionRepository permissionRepository)
    : ICommandHandler<CreateRoleCommand>
{
    public async ValueTask<Unit> Handle(
        CreateRoleCommand command,
        CancellationToken cancellationToken)
    {
        var permissions = await permissionRepository.GetAsync(cancellationToken);
        
        if (!permissions.Any(p => command.Permissions.Contains(p.Name)))
        {
            throw new InvalidOperationException("One or more permissions do not exist.");
        }

        var newRole = Role.Create(command.Name, [.. command.Permissions.Select(p => new Permission { Name = p })]);

        await roleRepository.AddAsync(newRole, cancellationToken);
        await roleRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
