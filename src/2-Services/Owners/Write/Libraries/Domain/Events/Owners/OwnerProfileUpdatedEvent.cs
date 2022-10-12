using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Domain.Events.Owners
{
    public class OwnerProfileUpdatedEvent : DomainEvent
    {
        public OwnerProfileUpdatedEvent(string id, string displayName, string email) : base(entityId: id, entityType: nameof(Owner))
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
