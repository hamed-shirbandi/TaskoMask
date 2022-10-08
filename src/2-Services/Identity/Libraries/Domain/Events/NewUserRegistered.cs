using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Domain.Events
{
    public class NewUserRegistered : DomainEvent
    {
        public NewUserRegistered(string id, string userName, string email) : base(entityId: id, entityType: nameof(User))
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
