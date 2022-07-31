using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.DomainModel.Workspace.Tasks.Events.Tasks
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
