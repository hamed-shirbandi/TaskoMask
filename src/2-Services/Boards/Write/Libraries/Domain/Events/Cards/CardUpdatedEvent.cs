using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.Services.Boards.Write.Domain.Entities;

namespace TaskoMask.Services.Boards.Write.Domain.Events.Cards
{
    public class CardUpdatedEvent : DomainEvent
    {
        public CardUpdatedEvent(string id, string name, BoardCardType type) : base(entityId: id, entityType: nameof(Card))
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public string Id { get; }
        public string Name { get;  }
        public BoardCardType Type { get; }
    }
}
