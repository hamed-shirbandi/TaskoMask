using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Boards
{
    public class BoardUpdatedEvent : DomainEvent
    {
        public BoardUpdatedEvent(string id, string name, string description) : base(entityId: id, entityType: nameof(Board))
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; }
        public string Name { get;  }
        public string Description { get; }
    }
}
