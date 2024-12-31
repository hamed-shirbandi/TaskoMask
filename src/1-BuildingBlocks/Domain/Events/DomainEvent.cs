using System;
using MediatR;

namespace TaskoMask.BuildingBlocks.Domain.Events;

/// <summary>
///
/// </summary>
public class DomainEvent : INotification
{
    public DomainEvent(string entityId, string entityType)
    {
        EntityId = entityId;
        EntityType = entityType;
        EventType = GetType().Name;
        OccurredOn = DateTime.Now;
    }

    public string EntityId { get; }
    public string EntityType { get; }
    public string EventType { get; }
    public DateTime OccurredOn { get; }
}
