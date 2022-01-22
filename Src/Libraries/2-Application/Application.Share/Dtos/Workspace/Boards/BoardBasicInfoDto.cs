using TaskoMask.Application.Share.Dtos.Common;

namespace TaskoMask.Application.Share.Dtos.Workspace.Boards
{
    public class BoardBasicInfoDto: BoardBaseDto
    {
        public CreationTimeDto CreationTime { get; set; }
        public string OrganizationId { get; set; }

    }
}
