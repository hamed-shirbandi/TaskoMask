using System.Collections.Generic;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Core.Notifications
{
    public interface IDomainNotificationHandler
    {
        void Add(string key, string value);
        void AddRange(List<DomainNotification> notifications);
        List<string> GetErrors();
        List<DomainNotification> GetList();
        List<DomainNotification> GetListAndReset();
        bool HasAny();
        void Reset();

    }
}
