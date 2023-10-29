using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Organizations;

public class OrganizationUpdatedEvent : DomainEvent
{
    public OrganizationUpdatedEvent(string id, string name, string description)
        : base(entityId: id, entityType: DomainMetadata.Organization)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
}
