using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Identity.Api.Domain.Events;

public class UserUpdatedEvent : DomainEvent
{
    public UserUpdatedEvent(string id, string email)
        : base(entityId: id, entityType: DomainMetadata.User)
    {
        Id = id;
        Email = email;
    }

    public string Id { get; }
    public string Email { get; }
}
