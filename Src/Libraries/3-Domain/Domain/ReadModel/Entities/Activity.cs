using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.ReadModel.Entities
{
    public class Activity : BaseEntity
    {
        public string TaskId { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }
    }
}
