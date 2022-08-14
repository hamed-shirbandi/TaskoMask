using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Events.Organizations
{
    public class OrganizationAddedEvent : DomainEvent
    {
        public OrganizationAddedEvent(string id, string name, string description, string ownerId) : base(entityId: id, entityType: nameof(Organization))
        {
            Id = id;
            Name = name;
            Description = description;
            OwnerId = ownerId;
        }

        public string Id { get; }
        public string Name { get; }
        public string Description { get;  }
        public string OwnerId { get;  }
    }
}
