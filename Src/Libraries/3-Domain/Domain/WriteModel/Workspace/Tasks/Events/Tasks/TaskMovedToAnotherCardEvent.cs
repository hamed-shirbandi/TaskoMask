using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Tasks
{
    public class TaskMovedToAnotherCardEvent : DomainEvent
    {
        public TaskMovedToAnotherCardEvent(string id, string cardId) : base(entityId: id, entityType: nameof(Task))
        {
            Id = id;
            CardId = cardId;
        }

        public string Id { get; }
        public string CardId { get;  }
    }
}
