using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Identity.Domain.Events
{
    public class NewUserRegisteredEvent : DomainEvent
    {
        public NewUserRegisteredEvent(string id, string userName, string email) : base(entityId: id, entityType: DomainMetadata.User)
        {
            Id = id;
            Email = email;
            UserName = userName;
        }


        public string Id { get; }
        public string Email { get; }
        public string UserName { get; }
    }
}
