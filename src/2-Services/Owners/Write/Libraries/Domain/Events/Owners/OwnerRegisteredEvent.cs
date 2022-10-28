using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Domain.Events.Owners
{
    public class OwnerRegisteredEvent : DomainEvent
    {
        public OwnerRegisteredEvent(string id, string email,string password) : base(entityId: id, entityType: DomainMetadata.Owner)
        {
            Id = id;
            Email = email;
            Password = password;

        }

        public string Id { get; }
        public string Email { get; }
        public string Password { get; }

    }
}
