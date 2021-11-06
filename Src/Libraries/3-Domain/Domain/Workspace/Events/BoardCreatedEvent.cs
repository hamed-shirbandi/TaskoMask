using TaskoMask.Domain.Workspace.Entities;
using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Domain.Workspace.Events
{
    public class BoardCreatedEvent : DomainEvent
    {
        public BoardCreatedEvent(string id, string name, string description, string projectId, string organizationId) : base(entityId: id, entityType: nameof(Board))
        {
            Id = id;
            Name = name;
            Description = description;
            ProjectId = projectId;
            OrganizationId = organizationId;
        }


        public string Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ProjectId { get; private set; }
        public string OrganizationId { get; private set; }

    }
}
