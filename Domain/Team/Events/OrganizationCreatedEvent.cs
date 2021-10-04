using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Team.Entities;

namespace TaskoMask.Domain.Team.Events
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
