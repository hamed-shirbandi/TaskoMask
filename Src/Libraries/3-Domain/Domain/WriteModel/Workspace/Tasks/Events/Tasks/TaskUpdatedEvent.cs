using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Tasks
{
    public class TaskUpdatedEvent : DomainEvent
    {
        public TaskUpdatedEvent(string id, string cardId, string title, string description) : base(entityId: id, entityType: nameof(Task))
        {
            Id = id;
            Title = title;
            CardId = cardId;
            Description = description;
        }

        public string Id { get; }
        public string Title { get;  }
        public string CardId { get; }
        public string Description { get; }
    }
}
