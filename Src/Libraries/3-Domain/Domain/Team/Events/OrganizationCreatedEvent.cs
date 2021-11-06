using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Team.Entities;

namespace TaskoMask.Domain.Team.Events
{
    public class OrganizationCreatedEvent : DomainEvent
    {
        public OrganizationCreatedEvent(string id, string name, string description, string ownerMemberId) : base(entityId: id, entityType: nameof(Organization))
        {
            Id = id;
            Name = name;
            Description = description;
            OwnerMemberId = ownerMemberId;
        }

        public string Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string OwnerMemberId { get; private set; }
    }
}
