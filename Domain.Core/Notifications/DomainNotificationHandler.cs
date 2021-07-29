using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);

            return Task.CompletedTask;
        }

        public IEnumerable<DomainNotification> GetList()
        {
            return _notifications;
        }

        public IEnumerable<DomainNotification> GetListAndReset()
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

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}