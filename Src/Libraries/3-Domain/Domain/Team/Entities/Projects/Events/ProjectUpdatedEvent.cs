using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Domain.Team.Entities.Projects.Events
{
    public class ProjectUpdatedEvent : DomainEvent
    {
        public ProjectUpdatedEvent(string id, string name, string description) : base(entityId: id, entityType: nameof(Project))
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
