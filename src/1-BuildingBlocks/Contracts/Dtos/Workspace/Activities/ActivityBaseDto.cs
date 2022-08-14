

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Activities
{
    public abstract class ActivityBaseDto
    {
        public string Id { get; set; }

        public string TaskId { get; set; }
        public string Description { get; set; }
    }
}
