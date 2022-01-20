using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Boards.Events.Boards
{
    public class BoardRecycledEvent : DomainEvent
    {
        public BoardRecycledEvent(string id) : base(entityId: id, entityType: nameof(Board))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
