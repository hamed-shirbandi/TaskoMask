using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Events.Comments
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
