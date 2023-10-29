using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.Events.Boards;

public class BoardDeletedEvent : DomainEvent
{
    public BoardDeletedEvent(string id)
        : base(entityId: id, entityType: DomainMetadata.Board)
    {
        Id = id;
    }

    public string Id { get; }
}
