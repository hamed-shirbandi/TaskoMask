using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Organizations
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
