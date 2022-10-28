using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Tasks.Write.Domain.Events.Tasks
{
    public class TaskDeletedEvent : DomainEvent
    {
        public TaskDeletedEvent(string id) : base(entityId: id, entityType: DomainMetadata.Task)
        {
            Id = id;
        }


        public string Id { get; }
    }
}
