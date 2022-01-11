using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Members.Entities;

namespace TaskoMask.Domain.Workspace.Members.Events
{
    public class MemberActivityStateChangedEvent : DomainEvent
    {
        public MemberActivityStateChangedEvent(string id, bool isActive) : base(entityId: id, entityType: nameof(Member))
        {
            Id = id;
            IsActive = isActive;
        }


        public string Id { get; }
        public bool IsActive { get; }
    }
}
