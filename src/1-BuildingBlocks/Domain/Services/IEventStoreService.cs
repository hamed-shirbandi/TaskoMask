using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Events;

namespace TaskoMask.BuildingBlocks.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEventStoreService
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
