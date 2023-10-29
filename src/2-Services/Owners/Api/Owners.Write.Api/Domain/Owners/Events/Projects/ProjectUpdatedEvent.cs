using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Projects;

public class ProjectUpdatedEvent : DomainEvent
{
    public ProjectUpdatedEvent(string id, string name, string description)
        : base(entityId: id, entityType: DomainMetadata.Project)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
}
