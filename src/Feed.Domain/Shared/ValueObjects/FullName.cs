namespace Feed.Domain.Shared.ValueObjects;

public sealed record FullName(string? FirstName, string? LastName, string? Patronymic)
{
    public static FullName Create(string? firstName, string? lastName, string? patronymic)
    {
        return new FullName(firstName?.Trim(), lastName?.Trim(), patronymic?.Trim());
    }

    public string Value => $"{FirstName} {LastName} {Patronymic}";

    public override string ToString() => Value;
}
