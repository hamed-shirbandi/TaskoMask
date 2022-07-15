using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Tasks
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
