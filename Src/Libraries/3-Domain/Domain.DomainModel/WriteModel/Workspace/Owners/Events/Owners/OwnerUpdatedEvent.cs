using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Owners
{
    public class OwnerUpdatedEvent : DomainEvent
    {
        public OwnerUpdatedEvent(string id, string displayName, string email) : base(entityId: id, entityType: nameof(Owner))
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
