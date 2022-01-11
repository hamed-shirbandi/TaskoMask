using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Members.Entities;

namespace TaskoMask.Domain.Workspace.Members.Events
{
    public class MemberDeletedEvent : DomainEvent
    {
        public MemberDeletedEvent(string id) : base(entityId: id, entityType: nameof(Member))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
