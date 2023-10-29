using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Projects;

public class ProjectDeletedEvent : DomainEvent
{
    public ProjectDeletedEvent(string id)
        : base(entityId: id, entityType: DomainMetadata.Project)
    {
        Id = id;
    }

    public string Id { get; }
}
