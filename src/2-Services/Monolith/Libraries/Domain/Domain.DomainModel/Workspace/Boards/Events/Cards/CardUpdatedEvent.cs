using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Cards
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
