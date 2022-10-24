using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Boards
{
    public class BoardDeletedEvent : DomainEvent
    {
        public BoardDeletedEvent(string id) : base(entityId: id, entityType: nameof(Board))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
