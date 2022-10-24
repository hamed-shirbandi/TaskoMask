using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Events.Organizations
{
    public class OrganizationUpdatedEvent : DomainEvent
    {
        public OrganizationUpdatedEvent(string id, string name, string description) : base(entityId: id, entityType: nameof(Organization))
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
