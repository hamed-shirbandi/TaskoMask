using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Projects
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
