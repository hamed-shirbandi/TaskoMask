using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.DomainModel.Workspace.Tasks.Events.Tasks
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
