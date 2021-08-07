using System.Collections.Generic;
using System.Linq;


namespace TaskoMask.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Add(string key, string value)
        {
            var notification = new DomainNotification(key,value);
            _notifications.Add(notification);
        }

        public List<string> GetErrors()
        {
            return _notifications.Select(n=>n.Value).ToList();
        }


        public List<DomainNotification> GetList()
        {
            return _notifications;
        }

        public List<DomainNotification> GetListAndReset()
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
            _notifications = new List<DomainNotification>();
        }

        
    }
}