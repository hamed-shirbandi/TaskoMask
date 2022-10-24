using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Domain.Events.Projects
{
    public class ProjectUpdatedEvent : DomainEvent
    {
        public ProjectUpdatedEvent(string id, string name, string description ) : base(entityId: id, entityType: nameof(Project))
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
