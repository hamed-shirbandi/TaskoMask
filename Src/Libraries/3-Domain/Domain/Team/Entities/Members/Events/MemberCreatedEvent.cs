using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Team.Entities;
using TaskoMask.Domain.Team.Entities.Members;

namespace TaskoMask.Domain.Team.Members.Events
{
    public class MemberCreatedEvent : DomainEvent
    {
        public MemberCreatedEvent(string id, string displayName, string email, string userName) : base(entityId: id, entityType: nameof(Member))
        {
            Id = id;
            DisplayName = displayName;
            UserName = userName;
            Email = email;
        }


        public string Id { get; }
        public string DisplayName { get; }
        public string UserName { get; }
        public string Email { get; }
    }
}
