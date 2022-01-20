using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Owners
{
    public class OwnerDeletedEvent : DomainEvent
    {
        public OwnerDeletedEvent(string id) : base(entityId: id, entityType: nameof(Owner))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
