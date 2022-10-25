using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.BuildingBlocks.Domain.EventContracts.Comments
{
    public class CommentAddedEvent : DomainEvent
    {
        public CommentAddedEvent(string id, string content, string taskId) : base(entityId: id, entityType: DomainMetadata.Comment)
        {
            Id = id;
            Content = content;
            TaskId = taskId;
        }


        public string Id { get; }
        public string Content { get; private set; }
        public string TaskId { get; private set; }
    }
}
