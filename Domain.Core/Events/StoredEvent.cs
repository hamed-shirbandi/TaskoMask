using System;

namespace TaskoMask.Domain.Core.Events
{
   public class StoredEvent
    {
        public StoredEvent(string id, string type, string userId, string requerst, string response )
        {
            Id = id;
            Type = type;
            UserId = userId;
            Requerst = requerst;
            Response = response;
            CreateDateTime = DateTime.Now;
        }

        public string Id { get; private set; }
        public string Type { get; private set; }
        public object Requerst { get; private set; }
        public object Response { get; private set; }
        public string UserId { get; private set; }
        public DateTime CreateDateTime { get; private set; }
    }
}
