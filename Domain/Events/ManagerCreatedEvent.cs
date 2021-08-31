using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Domain.Events
{
   public class ManagerCreatedEvent: DomainEvent
    {
        public ManagerCreatedEvent(string id):base(entityId: id, entityType:nameof(Manager))
        {

        }
    }
}
