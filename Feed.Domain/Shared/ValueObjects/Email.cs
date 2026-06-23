using System.Text.RegularExpressions;

namespace Feed.Domain.Shared.ValueObjects;

public sealed record Email(string Value)
{
    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new Exception("Email cannot be empty.");

        if (value.Length > 254)
            throw new Exception("Email must not exceed 254 characters.");

        if (!EmailRegex.IsMatch(value))
            throw new Exception($"'{value}' is not a valid email address.");

        return new Email(value.ToLowerInvariant());
    }

    public override string ToString() => Value;
}