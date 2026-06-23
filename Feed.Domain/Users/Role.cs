namespace Feed.Domain.Users;

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

    public void AddPermission(Permission permission)
    {
        if (_permissions.Contains(permission))
            return;

        _permissions.Add(permission);
    }

    public void RemovePermission(Permission permission)
    {
        _permissions.Remove(permission);
    }

    public bool HasPermission(Permission permission)
    {
        return _permissions.Contains(permission);
    }

    public void Update(string? name)
    {
        _name = name ?? _name;
    }
}