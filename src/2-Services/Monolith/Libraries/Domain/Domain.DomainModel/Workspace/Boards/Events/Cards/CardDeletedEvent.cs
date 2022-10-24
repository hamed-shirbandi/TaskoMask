using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Cards
{
    public class CardDeletedEvent : DomainEvent
    {
        public CardDeletedEvent(string id) : base(entityId: id, entityType: nameof(Card))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
