using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Domain.Events.Organizations
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
