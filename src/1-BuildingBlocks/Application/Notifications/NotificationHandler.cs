using System.Collections.Generic;
using System.Linq;

namespace TaskoMask.BuildingBlocks.Application.Notifications
{

    /// <summary>
    /// 
    /// </summary>
    public class NotificationHandler : INotificationHandler
    {
        private List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        public void Add(string key, string value)
        {
            var notification = new Notification(key,value);
            _notifications.Add(notification);
        }

        public void AddRange(List<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public List<string> GetErrors()
        {
            return _notifications.Select(n=>n.Value).ToList();
        }


        public List<Notification> GetList()
        {
            return _notifications;
        }

        public List<Notification> GetListAndReset()
        {
            var notifications=  _notifications;
            Reset();
            return notifications;
        }


        public bool HasAny()
        {
            return _notifications.Any();
        }


        public void Reset()
        {
            _notifications = new List<Notification>();
        }

        
    }
}