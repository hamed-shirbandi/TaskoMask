using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Tasks.Write.Domain.Entities;

namespace TaskoMask.Services.Tasks.Write.Domain.Events.Comments
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
