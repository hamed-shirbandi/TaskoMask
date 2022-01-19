using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Workspace.Boards.Entities;

namespace TaskoMask.Domain.Workspace.Boards.Events.Cards
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
