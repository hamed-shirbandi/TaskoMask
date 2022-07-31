using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Tasks
{
    public class TaskRecycledEvent : DomainEvent
    {
        public TaskRecycledEvent(string id) : base(entityId: id, entityType: nameof(Task))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
