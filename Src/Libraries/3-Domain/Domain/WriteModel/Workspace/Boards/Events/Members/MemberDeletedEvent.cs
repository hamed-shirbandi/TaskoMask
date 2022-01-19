using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Boards.Entities;

namespace TaskoMask.Domain.Workspace.Boards.Events.Members
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
