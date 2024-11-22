using System;

namespace TaskoMask.BuildingBlocks.Infrastructure.Services.EventStoring;

/// <summary>
///
/// </summary>
public class StoredEvent
{
    public StoredEvent(string entityId, string entityType, string eventType, string userId, object data)
    {
        EntityId = entityId;
        EntityType = entityType;
        EventType = eventType;
        UserId = userId;
        Data = data;
        CreateDateTime = DateTime.Now;
    }

    public string EntityId { get; private set; }
    public string EntityType { get; private set; }
    public string EventType { get; private set; }
    public object Data { get; private set; }
    public string UserId { get; private set; }
    public DateTime CreateDateTime { get; private set; }
}
