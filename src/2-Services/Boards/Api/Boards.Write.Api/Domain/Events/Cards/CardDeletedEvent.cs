using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Events.Cards
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
