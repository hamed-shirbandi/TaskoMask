using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Projects.Entities;

namespace TaskoMask.Domain.Projects.Events
{
    public class OrganizationCreatedEvent : DomainEvent
    {
        public OrganizationCreatedEvent(string id, string name, string description, string userId) : base(entityId: id, entityType: nameof(Organization))
        {
            Id = id;
            Name = name;
            Description = description;
            UserId = userId;
        }

        public string Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string UserId { get; private set; }
    }
}
