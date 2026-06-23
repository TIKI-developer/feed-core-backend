namespace Feed.Domain.Notifications;

public abstract class Notifier
{
    public abstract string Name { get; }

    public virtual void Notify(Notification notification)
    {
        Console.Write(notification.ToString());
    }
}
