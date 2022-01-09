using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Domain.Team.Entities.Members.Events
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
