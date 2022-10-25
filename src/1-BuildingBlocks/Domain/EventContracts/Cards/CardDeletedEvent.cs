using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.BuildingBlocks.Domain.EventContracts.Cards
{
    public class CardDeletedEvent : DomainEvent
    {
        public CardDeletedEvent(string id) : base(entityId: id, entityType: DomainMetadata.Card)
        {
            Id = id;
        }


        public string Id { get; }
    }
}
