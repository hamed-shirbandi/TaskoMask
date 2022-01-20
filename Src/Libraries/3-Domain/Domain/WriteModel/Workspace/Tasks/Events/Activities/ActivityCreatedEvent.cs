using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Activities
{
    public class ActivityCreatedEvent : DomainEvent
    {
        public ActivityCreatedEvent(string id,string description, string taskId ) : base(entityId: id, entityType: nameof(Activity))
        {
            Id = id;
            Description = description;
            TaskId = taskId;
        }


        public string Id { get; }
        public string Description { get; private set; }
        public string TaskId { get; private set; }

    }
}
