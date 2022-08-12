using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.DomainModel.Workspace.Tasks.Events.Comments
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
