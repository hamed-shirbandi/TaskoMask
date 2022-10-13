using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Tasks.Write.Domain.Entities;

namespace TaskoMask.Services.Tasks.Write.Domain.Events.Tasks
{
    public class TaskMovedToAnotherCardEvent : DomainEvent
    {
        public TaskMovedToAnotherCardEvent(string taskId, string cardId) : base(entityId: taskId, entityType: nameof(Task))
        {
            TaskId = taskId;
            CardId = cardId;
        }

        public string TaskId { get; }
        public string CardId { get;  }
    }
}
