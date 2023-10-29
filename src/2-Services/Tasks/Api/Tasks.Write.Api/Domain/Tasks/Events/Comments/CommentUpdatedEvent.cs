using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Comments;

public class CommentUpdatedEvent : DomainEvent
{
    public CommentUpdatedEvent(string id, string content)
        : base(entityId: id, entityType: DomainMetadata.Comment)
    {
        Id = id;
        Content = content;
    }

    public string Id { get; }
    public string Content { get; }
}
