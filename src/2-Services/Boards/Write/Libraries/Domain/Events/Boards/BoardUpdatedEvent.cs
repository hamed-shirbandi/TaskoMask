using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Boards.Write.Domain.Entities;

namespace TaskoMask.Services.Boards.Write.Domain.Events.Boards
{
    public class BoardUpdatedEvent : DomainEvent
    {
        public BoardUpdatedEvent(string id, string name, string description) : base(entityId: id, entityType: nameof(Board))
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; }
        public string Name { get;  }
        public string Description { get; }
    }
}
