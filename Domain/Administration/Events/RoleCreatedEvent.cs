using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Domain.Administration.Events
{
    public class RoleCreatedEvent : DomainEvent
    {
        public RoleCreatedEvent(string id, string name, string description) : base(entityId: id, entityType: nameof(Role))
        {
            Id = id;
            Name = name;
            Description = description;
        }


        public string Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
