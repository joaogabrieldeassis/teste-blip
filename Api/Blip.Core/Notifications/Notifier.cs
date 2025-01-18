using Blip.Core.Interfaces.Notifications;
using Blip.Core.Models;

namespace Blip.Core.Notifications;

public class Notifier : INotifier
{
    private readonly List<Notification> _notifications;

    public Notifier()
    {
        _notifications = [];
    }

    public void Handle(Notification notification)
        => _notifications.Add(notification);

    public List<Notification> GetNotifications()
        => _notifications;

    public bool HasNotification()
        => _notifications.Count != 0;
}