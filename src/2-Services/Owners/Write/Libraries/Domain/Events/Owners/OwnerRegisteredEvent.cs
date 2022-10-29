using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Domain.Events.Owners
{
    public class OwnerRegisteredEvent : DomainEvent
    {
        public OwnerRegisteredEvent(string id, string displayName,string email) : base(entityId: id, entityType: DomainMetadata.Owner)
        {
            Id = id;
            Email = email;
            DisplayName = displayName;

        }

        public string Id { get; }
        public string Email { get; }
        public string DisplayName { get; }

    }
}
