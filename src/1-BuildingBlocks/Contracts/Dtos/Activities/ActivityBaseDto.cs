

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Activities
{
    public abstract class ActivityBaseDto
    {
        public string Id { get; set; }

        public string TaskId { get; set; }
        public string Description { get; set; }
    }
}
