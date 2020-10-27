using System;

namespace TaskoMask.Domain.Core.Events
{
   public class StoredEvent
    {
        public StoredEvent(string entityId, string entityType, string eventType, string userId, string requerst, string response )
        {
            EntityId = entityId;
            EntityType = entityType;
            EventType = eventType;
            UserId = userId;
            Requerst = requerst;
            Response = response;
            CreateDateTime = DateTime.Now;
        }

        public string EntityId { get; private set; }
        public string EntityType { get; private set; }
        public string EventType { get; private set; }
        public object Requerst { get; private set; }
        public object Response { get; private set; }
        public string UserId { get; private set; }
        public DateTime CreateDateTime { get; private set; }
    }
}
