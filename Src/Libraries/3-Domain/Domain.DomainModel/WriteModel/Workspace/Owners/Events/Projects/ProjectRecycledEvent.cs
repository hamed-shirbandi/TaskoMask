using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Projects
{
    public class ProjectRecycledEvent : DomainEvent
    {
        public ProjectRecycledEvent(string id) : base(entityId: id, entityType: nameof(Project))
        {
            Id = id;
        }


        public string Id { get; }
    }
}
