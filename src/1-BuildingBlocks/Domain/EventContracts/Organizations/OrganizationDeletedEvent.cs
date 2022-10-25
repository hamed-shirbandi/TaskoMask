using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.BuildingBlocks.Domain.EventContracts.Organizations
{
    public class OrganizationDeletedEvent : DomainEvent
    {
        public OrganizationDeletedEvent(string id) : base(entityId: id, entityType: DomainMetadata.Organization)
        {
            Id = id;
        }


        public string Id { get; }
    }
}
