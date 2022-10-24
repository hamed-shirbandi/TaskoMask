using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Events.Owners
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
