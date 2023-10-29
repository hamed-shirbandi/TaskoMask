using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Comments;

public class CommentDeletedEvent : DomainEvent
{
    public CommentDeletedEvent(string id)
        : base(entityId: id, entityType: DomainMetadata.Comment)
    {
        Id = id;
    }

    public string Id { get; }
}
