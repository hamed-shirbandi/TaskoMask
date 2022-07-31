using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Projects
{
    public class ProjectCreatedEvent : DomainEvent
    {
        public ProjectCreatedEvent(string id, string name, string description, string organizationId, string ownerId) : base(entityId: id, entityType: nameof(Project))
        {
            Id = id;
            Name = name;
            Description = description;
            OrganizationId = organizationId;
            OwnerId = ownerId;
        }

        public string Id { get; }
        public string Name { get; }
        public string Description { get;  }
        public string OrganizationId { get;  }
        public string OwnerId { get; }

    }
}
