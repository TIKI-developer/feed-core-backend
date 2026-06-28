using Feed.Domain.Shared.ValueObjects;

namespace Feed.Domain.Notifications.Entities;

public class Notification
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Body { get; private set; }
    public Guid UserId { get; private set; }
    public Timestamps Timestamps { get; private set; }

    private Notification(Guid id, string title, string body, Guid userId, Timestamps timestamps)
    {
        Id = id;
        Title = title;
        Body = body;
        UserId = userId;
        Timestamps = timestamps;
    }

    public static Notification Create(string title, string body, Guid userId)
    {
        return new Notification(Guid.NewGuid(), title, body, userId, Timestamps.Create());
    }

    public static Notification Restore(string title, string body, Guid userId, Timestamps timestamps)
    {
        return new Notification(Guid.NewGuid(), title, body, userId, timestamps);
    }
}
