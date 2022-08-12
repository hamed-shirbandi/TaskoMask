using TaskoMask.Application.Share.Dtos.Common;

namespace TaskoMask.Application.Share.Dtos.Workspace.Tasks
{
    public class TaskBasicInfoDto: TaskBaseDto
    {
        public CreationTimeDto CreationTime { get; set; }

        public string BoardId { get; set; }
        public string ProjectId { get; set; }
        public string OrganizationId { get; set; }
    }
}
