using MediatR;
using Newtonsoft.Json;
using System;

namespace TaskoMask.BuildingBlocks.Domain.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class DomainEvent : INotification
    {
        public DomainEvent(string entityId, string entityType)
        {
            EntityId = entityId;
            EntityType = entityType;
            EventType = GetType().Name;
            OccurredOn = DateTime.Now;
        }

        /// <summary>
        /// Use JsonIgnore to prevent adding it to Data prop in StoredEvent because it will map to EntityId prop in StoredEvent
        /// </summary>
        [JsonIgnore]
        public string EntityId { get; }

        /// <summary>
        /// Use JsonIgnore to prevent adding it to Data prop in StoredEvent because it will map to EntityType prop in StoredEvent
        /// </summary>
        [JsonIgnore]
        public string EntityType { get; }

        /// <summary>
        /// Use JsonIgnore to prevent adding it to Data prop in StoredEvent because it will map to EventType prop in StoredEvent
        /// </summary>
        [JsonIgnore]
        public string EventType { get; }

        public DateTime OccurredOn { get; }
    }
}
