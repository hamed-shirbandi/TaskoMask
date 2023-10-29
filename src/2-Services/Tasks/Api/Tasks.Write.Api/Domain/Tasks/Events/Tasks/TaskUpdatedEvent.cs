using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Tasks;

public class TaskUpdatedEvent : DomainEvent
{
    public TaskUpdatedEvent(string id, string title, string description)
        : base(entityId: id, entityType: DomainMetadata.Task)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public string Id { get; }
    public string Title { get; }
    public string Description { get; }
}
