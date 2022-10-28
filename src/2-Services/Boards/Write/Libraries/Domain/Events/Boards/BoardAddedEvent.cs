using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Boards.Write.Domain.Events.Boards
{
    public class BoardAddedEvent : DomainEvent
    {
        public BoardAddedEvent(string id, string name, string description, string projectId) : base(entityId: id, entityType: DomainMetadata.Board)
        {
            Id = id;
            Name = name;
            Description = description;
            ProjectId = projectId;
        }


        public string Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ProjectId { get; private set; }

    }
}
