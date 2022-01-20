using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.ReadModel.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string OwnerId { get; set; }
    }
}
