using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Owners.Entities;

namespace TaskoMask.Domain.Workspace.Owners.Events
{
    public class OwnerActivityStateChangedEvent : DomainEvent
    {
        public OwnerActivityStateChangedEvent(string id, bool isActive) : base(entityId: id, entityType: nameof(Owner))
        {
            Id = id;
            IsActive = isActive;
        }


        public string Id { get; }
        public bool IsActive { get; }
    }
}
