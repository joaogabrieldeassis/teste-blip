using Blip.Core.Models;

namespace Blip.Core.Interfaces.Notifications;

public interface INotifier
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}