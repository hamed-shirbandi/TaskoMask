using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskoMask.Domain.Core.Events
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// 
        /// </summary>
        void Save<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent;

        /// <summary>
        /// 
        /// </summary>
        Task SaveAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent;

        /// <summary>
        /// 
        /// </summary>
        Task<List<TStoredEvent>> GetListAsync<TStoredEvent>(string entityId, string entityType) where TStoredEvent : StoredEvent;
    }
}
