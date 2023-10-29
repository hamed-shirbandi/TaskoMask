using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.Events.Cards;

public class CardUpdatedEvent : DomainEvent
{
    public CardUpdatedEvent(string id, string name, BoardCardType type)
        : base(entityId: id, entityType: DomainMetadata.Card)
    {
        Id = id;
        Name = name;
        Type = type;
    }

    public string Id { get; }
    public string Name { get; }
    public BoardCardType Type { get; }
}
