using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Tasks.Write.Domain.Entities;

namespace TaskoMask.Services.Tasks.Write.Domain.Events.Comments
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
