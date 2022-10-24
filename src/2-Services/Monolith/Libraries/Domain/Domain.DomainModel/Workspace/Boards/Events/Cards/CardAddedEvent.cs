using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Cards
{
    public class CardAddedEvent : DomainEvent
    {
        public CardAddedEvent(string id, string name, BoardCardType type, string boardId) : base(entityId: id, entityType: nameof(Card))
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
