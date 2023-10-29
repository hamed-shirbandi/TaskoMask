using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Owners;

public class OwnerRegisteredEvent : DomainEvent
{
    public OwnerRegisteredEvent(string id, string displayName, string email)
        : base(entityId: id, entityType: DomainMetadata.Owner)
    {
        Id = id;
        Email = email;
        DisplayName = displayName;
    }

    public string Id { get; }
    public string Email { get; }
    public string DisplayName { get; }
}
