using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Members.Entities;

namespace TaskoMask.Domain.Workspace.Members.Events
{
    public class MemberUpdatedEvent : DomainEvent
    {
        public MemberUpdatedEvent(string id, string displayName, string email) : base(entityId: id, entityType: nameof(Member))
        {
            Id = id;
            DisplayName = displayName;
            Email = email;
        }


        public string Id { get; }
        public string DisplayName { get; }
        public string Email { get; }
    }
}
