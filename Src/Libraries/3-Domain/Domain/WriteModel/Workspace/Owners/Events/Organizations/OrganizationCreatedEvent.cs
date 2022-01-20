using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Organizations
{
    public class OrganizationCreatedEvent : DomainEvent
    {
        public OrganizationCreatedEvent(string id, string name, string description, string ownerOwnerId) : base(entityId: id, entityType: nameof(Organization))
        {
            Id = id;
            Name = name;
            Description = description;
            OwnerOwnerId = ownerOwnerId;
        }

        public string Id { get; }
        public string Name { get; }
        public string Description { get;  }
        public string OwnerOwnerId { get;  }
    }
}
