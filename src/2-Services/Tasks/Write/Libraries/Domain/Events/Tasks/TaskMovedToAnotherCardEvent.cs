using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Tasks.Write.Domain.Events.Tasks
{
    public class TaskMovedToAnotherCardEvent : DomainEvent
    {
        public TaskMovedToAnotherCardEvent(string taskId, string cardId) : base(entityId: taskId, entityType: DomainMetadata.Task)
        {
            TaskId = taskId;
            CardId = cardId;
        }

        public string TaskId { get; }
        public string CardId { get;  }
    }
}
