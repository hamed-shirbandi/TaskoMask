using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Events.Tasks
{
    public class TaskAddedEvent : DomainEvent
    {
        public TaskAddedEvent(string id, string title, string description, string cardId, string boardId) : base(entityId: id, entityType: nameof(Task))
        {
            Id = id;
            Title = title;
            Description = description;
            CardId = cardId;
            BoardId = boardId;
        }


        public string Id { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string CardId { get; private set; }
        public string BoardId { get; private set; }

    }
}
