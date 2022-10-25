using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.BuildingBlocks.Domain.EventContracts.Comments
{
    public class CommentDeletedEvent : DomainEvent
    {
        public CommentDeletedEvent(string id) : base(entityId: id, entityType: DomainMetadata.Comment)
        {
            Id = id;
        }


        public string Id { get; }
    }
}
