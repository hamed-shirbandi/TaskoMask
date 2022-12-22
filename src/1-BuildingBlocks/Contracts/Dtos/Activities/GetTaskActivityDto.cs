using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Activities
{
    public class GetTaskActivityDto
    {
        public string Id { get; set; }

        public string TaskId { get; set; }
        public string Description { get; set; }

        public CreationTimeDto CreationTime { get; set; }

    }
}
