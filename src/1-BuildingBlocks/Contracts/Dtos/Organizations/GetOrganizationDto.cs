using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations
{
    public class GetOrganizationDto : OrganizationBaseDto
    {
        public CreationTimeDto CreationTime { get; set; }
    }
}
