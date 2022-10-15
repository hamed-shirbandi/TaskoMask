using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks
{
    public class TaskBasicInfoDto: TaskBaseDto
    {
        public CreationTimeDto CreationTime { get; set; }

        public string BoardId { get; set; }
        public string ProjectId { get; set; }
        public string OrganizationId { get; set; }
    }
}
