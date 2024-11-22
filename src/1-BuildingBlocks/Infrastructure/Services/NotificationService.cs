using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.BuildingBlocks.Infrastructure.Services;

public class NotificationService : INotificationService
{
    private List<string> notifications;

    public NotificationService()
    {
        notifications = new List<string>();
    }

    public void Add(string notification)
    {
        notifications.Add(notification);
    }

    public void AddRange(List<string> notifications)
    {
        this.notifications.AddRange(notifications);
    }

    public List<string> GetList()
    {
        return notifications;
    }

    public List<string> GetListAndReset()
    {
        var notifications = this.notifications;
        Reset();
        return notifications;
    }

    public bool HasAny()
    {
        return notifications.Count != 0;
    }

    public void Reset()
    {
        notifications = new List<string>();
    }
}
