using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.Workspace.Tasks.Events.Tasks
{
    public class TaskUpdatedEvent : DomainEvent
    {
        public TaskUpdatedEvent(string id, string name, string description) : base(entityId: id, entityType: nameof(Task))
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; }
        public string Name { get;  }
        public string Description { get; }
    }
}
