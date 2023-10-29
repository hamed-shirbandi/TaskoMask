using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Owners;

public class OwnerProfileUpdatedEvent : DomainEvent
{
    public OwnerProfileUpdatedEvent(string id, string displayName, string email)
        : base(entityId: id, entityType: DomainMetadata.Owner)
    {
        Id = id;
        DisplayName = displayName;
        Email = email;
    }

    public string Id { get; }
    public string DisplayName { get; }
    public string Email { get; }
}
