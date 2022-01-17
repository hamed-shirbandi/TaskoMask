using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Owners.Entities;

namespace TaskoMask.Domain.Workspace.Owners.Events
{
    public class OwnerPasswordSetEvent : DomainEvent
    {
        public OwnerPasswordSetEvent(string id, string passwordHash, string passwordSalt) : base(entityId: id, entityType: nameof(Owner))
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
