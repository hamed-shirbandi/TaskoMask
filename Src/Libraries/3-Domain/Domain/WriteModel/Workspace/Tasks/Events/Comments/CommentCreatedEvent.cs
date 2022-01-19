using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.Workspace.Tasks.Events.Comments
{
    public class CommentCreatedEvent : DomainEvent
    {
        public CommentCreatedEvent(string id, string content, string taskId) : base(entityId: id, entityType: nameof(Comment))
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
