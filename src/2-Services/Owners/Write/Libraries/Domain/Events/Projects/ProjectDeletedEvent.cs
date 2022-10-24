using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Domain.Events.Projects
{
    public class ProjectDeletedEvent : DomainEvent
    {
        public ProjectDeletedEvent(string id) : base(entityId: id, entityType: nameof(Project))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
