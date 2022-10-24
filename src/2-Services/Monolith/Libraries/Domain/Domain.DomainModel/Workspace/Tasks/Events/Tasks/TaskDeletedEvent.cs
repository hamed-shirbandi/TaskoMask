using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Events.Tasks
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
