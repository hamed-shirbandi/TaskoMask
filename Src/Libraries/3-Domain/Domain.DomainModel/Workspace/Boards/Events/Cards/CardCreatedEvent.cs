using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Domain.DomainModel.Workspace.Boards.Events.Cards
{
    public class CardCreatedEvent : DomainEvent
    {
        public CardCreatedEvent(string id, string name, BoardCardType type, string boardId) : base(entityId: id, entityType: nameof(Card))
        {
            Id = id;
            Name = name;
            Type = type;
            BoardId = boardId;
        }

        public string Id { get; }
        public string Name { get; private set; }
        public BoardCardType Type { get; private set; }
        public string BoardId { get; private set; }
    }
}
