using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Organizations.Entities;

namespace TaskoMask.Domain.Workspace.Boards.Events.Members
{
    public class MemberUpdatedEvent : DomainEvent
    {
        public MemberUpdatedEvent(string id, string name, string description) : base(entityId: id, entityType: nameof(Organization))
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; }
        public string Name { get;  }
        public string Description { get; }
    }
}
