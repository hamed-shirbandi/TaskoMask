using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.BuildingBlocks.Domain.EventContracts.Boards
{
    public class BoardDeletedEvent : DomainEvent
    {
        public BoardDeletedEvent(string id) : base(entityId: id, entityType: DomainMetadata.Board)
        {
            Id = id;
        }


        public string Id { get; }
    }
}
