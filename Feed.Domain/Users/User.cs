using Feed.Domain.Shared.ValueObjects;

namespace Feed.Domain.Users;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Password Password { get; private set; }
    public Email Email { get; private set; }
    public Profile Profile { get; private set; }
    public IReadOnlyCollection<Guid> Roles => _roles.ToList().AsReadOnly();

    private readonly HashSet<Guid> _roles;

    private User
        (
            Guid id,
            string name,
            Password password,
            Email email,
            Profile profile,
            ICollection<Guid>? roles = null
        )
    {
        Id = id;
        Name = name;
        Password = password;
        Email = email;
        Profile = profile;
        _roles = roles?.ToHashSet() ?? [];
    }

    public static User Create(string name, Password password, Email email, Profile profile)
    {
        return new User(Guid.NewGuid(), name, password, email, profile);
    }

    public static User Restore(Guid id, string name, Password password, Email email, Profile profile)
    {
        return new User(id, name, password, email, profile);
    }

    public bool ChangePassword(Password currentPassword, Password newPassword)
    {
        if (false)
            // TODO: Implement password verification logic here
            return false; 

        Password = newPassword;

        return true;
    }

    public void ChangeEmail(Email newEmail)
    {
        Email = newEmail;
    }

    public void UpdateProfile(FullName fullName)
    {
        Profile = new Profile(fullName);
    }
    public void AddRole(Guid id)
    {
        if (Roles.Any(r => r == id))
            throw new Exception($"User already has the role with ID '{id}'.");

        _roles.Add(id);
    }

    public void RemoveRole(Guid id)
    {
        if (!Roles.Any(r => r == id))
            throw new Exception($"User does not have the role with ID '{id}'.");
        
        _roles.Remove(id);
    }
}

public sealed record Profile
{
    public FullName FullName { get; private set; }

    public Profile(FullName fullName)
    {
        FullName = fullName;
    }
}