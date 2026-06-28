namespace Feed.Domain.Notifications.Entities;

public abstract class Notifier
{
    public abstract string Name { get; }

    public virtual void Notify(Notification notification) { }
}
