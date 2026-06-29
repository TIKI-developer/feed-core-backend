namespace Feed.Domain.Users.Entities;

public class Role
{
    private string _name;
    private readonly HashSet<Permission> _permissions;

    public string Name => _name;
    public IReadOnlyCollection<Permission> Permissions => [.. _permissions];

    private Role(string name, ICollection<Permission> permissions)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Role name cannot be empty");

        _name = name;
        _permissions = [.. permissions];
    }

    public static Role Create(string name)
    {
        return new Role(name, []);
    }

    public static Role Restore(string name, ICollection<Permission> permissions)
    {
        return new Role(name, permissions);
    }

    public bool HasPermission(Permission permission)
    {
        return _permissions.Contains(permission);
    }

    public void Update(string? name, ICollection<Permission>? permissions)
    {
        _name = name ?? _name;

        if (permissions != null)
        {
            _permissions.Clear();
            _permissions.UnionWith(permissions);
        }
    }
}