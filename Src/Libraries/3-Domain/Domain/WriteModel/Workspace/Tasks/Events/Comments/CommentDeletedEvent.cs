using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Comments
{
    public class CommentDeletedEvent : DomainEvent
    {
        public CommentDeletedEvent(string id) : base(entityId: id, entityType: nameof(Comment))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
