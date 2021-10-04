using TaskoMask.Domain.TaskManagement.Entities;
using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Domain.TaskManagement.Events
{
    public class CardCreatedEvent : DomainEvent
    {
        public CardCreatedEvent(string id, string name, string description, string boardId, string projectId, string organizationId) : base(entityId: id, entityType: nameof(Card))
        {
            Id = id;
            Name = name;
            Description = description;
            ProjectId = projectId;
            BoardId = boardId;
            OrganizationId = organizationId;
        }


        public string Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ProjectId { get; private set; }
        public string BoardId { get; private set; }
        public string OrganizationId { get; private set; }

    }
}
