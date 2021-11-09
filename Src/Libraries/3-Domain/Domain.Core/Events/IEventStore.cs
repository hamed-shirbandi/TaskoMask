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
        void Save<T>(T @event) where T : IDomainEvent;

        /// <summary>
        /// 
        /// </summary>
        Task SaveAsync<T>(T @event) where T : IDomainEvent;

        /// <summary>
        /// 
        /// </summary>
        Task<List<T>> GetListAsync<T>(string entityId, string entityType) where T : StoredEvent;
    }
}
