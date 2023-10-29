using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Tasks;

public class TaskMovedToAnotherCardEvent : DomainEvent
{
    public TaskMovedToAnotherCardEvent(string taskId, string cardId)
        : base(entityId: taskId, entityType: DomainMetadata.Task)
    {
        TaskId = taskId;
        CardId = cardId;
    }

    public string TaskId { get; }
    public string CardId { get; }
}
