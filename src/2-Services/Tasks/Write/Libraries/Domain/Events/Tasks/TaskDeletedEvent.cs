using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Tasks.Write.Domain.Entities;

namespace TaskoMask.Services.Tasks.Write.Domain.Events.Tasks
{
    public class TaskDeletedEvent : DomainEvent
    {
        public TaskDeletedEvent(string id) : base(entityId: id, entityType: nameof(Task))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
