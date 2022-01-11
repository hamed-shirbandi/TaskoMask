using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Members.Entities;

namespace TaskoMask.Domain.Workspace.Members.Events
{
    public class MemberPasswordSetEvent : DomainEvent
    {
        public MemberPasswordSetEvent(string id, string passwordHash, string passwordSalt) : base(entityId: id, entityType: nameof(Member))
        {
            Id = id;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public string Id { get; }
        public string PasswordHash { get; }
        public string PasswordSalt { get; }
    }
}
