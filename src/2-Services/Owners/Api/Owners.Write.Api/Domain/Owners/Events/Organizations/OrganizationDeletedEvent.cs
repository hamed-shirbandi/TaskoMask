using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Organizations;

public class OrganizationDeletedEvent : DomainEvent
{
    public OrganizationDeletedEvent(string id)
        : base(entityId: id, entityType: DomainMetadata.Organization)
    {
        Id = id;
    }

    public string Id { get; }
}
