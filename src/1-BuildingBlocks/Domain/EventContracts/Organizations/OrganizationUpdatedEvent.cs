using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.BuildingBlocks.Domain.EventContracts.Organizations
{
    public class OrganizationUpdatedEvent : DomainEvent
    {
        public OrganizationUpdatedEvent(string id, string name, string description) : base(entityId: id, entityType: DomainMetadata.Organization)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; }
        public string Name { get;  }
        public string Description { get; }
    }
}
