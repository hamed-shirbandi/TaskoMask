using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Domain.Core.Events
{
   public class StoredEvent
    {
        public StoredEvent(string type, string userId, string requerst, string response )
        {
            Type = type;
            UserId = userId;
            Requerst = requerst;
            Response = response;
            CreateDateTime = DateTime.Now;
        }

        public string Type { get; private set; }
        public object Requerst { get; private set; }
        public object Response { get; private set; }
        public string UserId { get; private set; }
        public DateTime CreateDateTime { get; private set; }
    }
}
