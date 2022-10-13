using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Tasks.Write.Domain.Entities;

namespace TaskoMask.Services.Tasks.Write.Domain.Events.Comments
{
    public class CommentAddedEvent : DomainEvent
    {
        public CommentAddedEvent(string id, string content, string taskId) : base(entityId: id, entityType: nameof(Comment))
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
