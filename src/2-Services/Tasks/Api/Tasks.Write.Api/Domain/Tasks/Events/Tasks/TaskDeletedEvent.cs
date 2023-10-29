using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Tasks;

public class TaskDeletedEvent : DomainEvent
{
    public TaskDeletedEvent(string id)
        : base(entityId: id, entityType: DomainMetadata.Task)
    {
        Id = id;
    }

    public string Id { get; }
}
