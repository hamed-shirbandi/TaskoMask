using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards
{
    public class BoardBasicInfoDto: BoardBaseDto
    {
        public CreationTimeDto CreationTime { get; set; }
        public string OrganizationId { get; set; }

    }
}
