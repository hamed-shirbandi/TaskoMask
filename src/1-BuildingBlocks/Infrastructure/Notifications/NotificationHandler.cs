using System.Collections.Generic;
using System.Linq;
using TaskoMask.BuildingBlocks.Application.Notifications;

namespace TaskoMask.BuildingBlocks.Infrastructure.Notifications;

/// <summary>
///
/// </summary>
public class NotificationHandler : INotificationHandler
{
    private List<Notification> notifications;

    public NotificationHandler()
    {
        notifications = new List<Notification>();
    }

    public void Add(string key, string value)
    {
        var notification = new Notification(key, value);
        notifications.Add(notification);
    }

    public void AddRange(List<Notification> notifications)
    {
        this.notifications.AddRange(notifications);
    }

    public List<string> GetErrors()
    {
        return notifications.Select(n => n.Value).ToList();
    }

    public List<Notification> GetList()
    {
        return notifications;
    }

    public List<Notification> GetListAndReset()
    {
        var notifications = this.notifications;
        Reset();
        return notifications;
    }

    public bool HasAny()
    {
        return notifications.Any();
    }

    public void Reset()
    {
        notifications = new List<Notification>();
    }
}
