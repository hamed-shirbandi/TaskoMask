using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Domain.Team.Entities.Organizations.Events
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
        public string Name { get; }
        public string Description { get;  }
        public string OwnerMemberId { get;  }
    }
}
