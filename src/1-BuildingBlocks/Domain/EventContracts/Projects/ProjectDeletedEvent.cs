using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.BuildingBlocks.Domain.EventContracts.Projects
{
    public class ProjectDeletedEvent : DomainEvent
    {
        public ProjectDeletedEvent(string id) : base(entityId: id, entityType: DomainMetadata.Project)
        {
            Id = id;
        }


        public string Id { get; }
    }
}
