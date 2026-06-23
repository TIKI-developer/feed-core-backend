namespace Feed.Domain.Notifications;

public class Notification
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Body { get; private set; }
    public Guid UserId { get; private set; }

    private Notification(Guid id, string title, string body, Guid userId)
    {
        Id = id;
        Title = title;
        Body = body;
        UserId = userId;
    }

    public static Notification Create(string title, string body, Guid userId)
    {
        return new Notification(Guid.NewGuid(), title, body, userId);
    }
}
