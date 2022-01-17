using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Workspace.Organizations.Entities;

namespace TaskoMask.Domain.Workspace.Organizations.Events
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
