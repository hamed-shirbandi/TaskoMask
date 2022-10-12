using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Domain.Events.Organizations
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
