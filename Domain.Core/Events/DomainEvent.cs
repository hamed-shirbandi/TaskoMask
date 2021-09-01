using MediatR;
using Newtonsoft.Json;
using System;

namespace TaskoMask.Domain.Core.Events
{

    /// <summary>
    /// 
    /// </summary>
    public class DomainEvent : IDomainEvent
    {
        public DomainEvent(string entityId,string entityType)
        {
            EntityId = entityId;
            EntityType = entityType;
            OccurredOn = DateTime.Now;
        }

        [JsonIgnore]
        public string EntityId { get;  }

        [JsonIgnore]

        public string EntityType { get;  }


        public DateTime OccurredOn { get; }
    }
}
