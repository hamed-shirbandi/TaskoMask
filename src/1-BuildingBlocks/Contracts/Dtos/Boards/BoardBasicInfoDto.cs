using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Boards
{
    public class BoardBasicInfoDto: BoardBaseDto
    {
        public CreationTimeDto CreationTime { get; set; }
        public string OrganizationId { get; set; }

    }
}
