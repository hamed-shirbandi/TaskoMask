using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Events.Tasks
{
    public class TaskUpdatedEvent : DomainEvent
    {
        public TaskUpdatedEvent(string id , string title, string description) : base(entityId: id, entityType: nameof(Task))
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public string Id { get; }
        public string Title { get;  }
        public string Description { get; }
    }
}
