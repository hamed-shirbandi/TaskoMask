using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Events.Projects
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
