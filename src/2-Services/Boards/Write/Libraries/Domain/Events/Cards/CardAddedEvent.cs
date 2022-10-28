using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Boards.Write.Domain.Events.Cards
{
    public class CardAddedEvent : DomainEvent
    {
        public CardAddedEvent(string id, string name, BoardCardType type, string boardId) : base(entityId: id, entityType: DomainMetadata.Card)
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
