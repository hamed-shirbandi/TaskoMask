using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Projects;

public class ProjectAddedEvent : DomainEvent
{
    public ProjectAddedEvent(string id, string name, string description, string organizationId, string ownerId)
        : base(entityId: id, entityType: DomainMetadata.Project)
    {
        Id = id;
        Name = name;
        Description = description;
        OrganizationId = organizationId;
        OwnerId = ownerId;
    }

    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string OrganizationId { get; }
    public string OwnerId { get; }
}
