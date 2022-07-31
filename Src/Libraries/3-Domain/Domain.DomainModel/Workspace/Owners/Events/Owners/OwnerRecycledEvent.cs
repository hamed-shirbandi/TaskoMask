using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.DomainModel.Workspace.Owners.Events.Owners
{
    public class OwnerRecycledEvent : DomainEvent
    {
        public OwnerRecycledEvent(string id) : base(entityId: id, entityType: nameof(Owner))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
