namespace Feed.Persistence.Entities;

internal class RoleEntity
{
    public required string Name { get; init; }
    public required ICollection<PermissionEntity> Permissions { get; init; }
}
