using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.Events.Boards;

public class BoardUpdatedEvent : DomainEvent
{
    public BoardUpdatedEvent(string id, string name, string description)
        : base(entityId: id, entityType: DomainMetadata.Board)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
}
