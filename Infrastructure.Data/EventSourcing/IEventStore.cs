using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Infrastructure.Data.EventSourcing
{
    public interface IEventStore
    {
        void Save<T>(T eventData) where T : StoredEvent;
        Task SaveAsync<T>(T eventData) where T : StoredEvent;
        Task<List<T>> GetListAsync<T>(string entityId, string entityType) where T : StoredEvent;
    }
}
