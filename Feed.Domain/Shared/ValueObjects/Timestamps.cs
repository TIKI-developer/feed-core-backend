namespace Feed.Domain.Shared.ValueObjects;

public sealed record Timestamps
{
    public DateTime CreatedAt => _createdAt;
    public DateTime UpdatedAt => _updatedAt;

    private readonly DateTime _createdAt;
    private readonly DateTime _updatedAt;

    private Timestamps(DateTime createdAt, DateTime updatedAt)
    {
        _createdAt = createdAt;
        _updatedAt = updatedAt;
    }

    public static Timestamps Create()
    {
        return new Timestamps(DateTime.UtcNow, DateTime.UtcNow);
    }

    public static Timestamps Restore(DateTime createdAt, DateTime updatedAt)
    {
        return new Timestamps(createdAt, updatedAt);
    }

    public Timestamps Touch()
    {
        return new Timestamps(_createdAt, DateTime.UtcNow);
    }
}