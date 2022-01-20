using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Comments
{
    public class CommentUpdatedEvent : DomainEvent
    {
        public CommentUpdatedEvent(string id, string content) : base(entityId: id, entityType: nameof(Comment))
        {
            Id = id;
            Content = content;
        }

        public string Id { get; }
        public string Content { get;  }
    }
}
