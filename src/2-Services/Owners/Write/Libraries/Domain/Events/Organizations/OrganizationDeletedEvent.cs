using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Domain.Events.Organizations
{
    public class OrganizationDeletedEvent : DomainEvent
    {
        public OrganizationDeletedEvent(string id) : base(entityId: id, entityType: nameof(Organization))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
