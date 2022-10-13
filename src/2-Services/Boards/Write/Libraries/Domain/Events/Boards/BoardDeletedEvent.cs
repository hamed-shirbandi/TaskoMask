using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Boards.Write.Domain.Entities;

namespace TaskoMask.Services.Boards.Write.Domain.Events.Boards
{
    public class BoardDeletedEvent : DomainEvent
    {
        public BoardDeletedEvent(string id) : base(entityId: id, entityType: nameof(Board))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
