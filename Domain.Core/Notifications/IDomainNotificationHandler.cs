using System.Collections.Generic;


namespace TaskoMask.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler
    {
        void Add(string key, string value);
        List<string> GetErrors();
        List<DomainNotification> GetList();
        List<DomainNotification> GetListAndReset();
        bool HasAny();
        void Reset();

    }
}
