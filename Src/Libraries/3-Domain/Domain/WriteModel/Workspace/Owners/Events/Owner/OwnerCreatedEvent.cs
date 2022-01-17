using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Owners.Entities;

namespace TaskoMask.Domain.Workspace.Owners.Events
{
    public class OwnerCreatedEvent : DomainEvent
    {
        public OwnerCreatedEvent(string id, string displayName, string email) : base(entityId: id, entityType: nameof(Owner))
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
