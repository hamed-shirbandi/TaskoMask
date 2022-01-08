using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Domain.Team.Entities.Projects.Events
{
    public class ProjectUpdatedEvent : DomainEvent
    {
        public ProjectUpdatedEvent(string id, string name, string description, string organizationId) : base(entityId: id, entityType: nameof(Project))
        {
            Id = id;
            Name = name;
            Description = description;
            OrganizationId = organizationId;
        }

        public string Id { get; }
        public string Name { get;  }
        public string Description { get; }
        public string OrganizationId { get; }
    }
}
