using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.ReadModel.Entities
{
    public class Board : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectId { get; set; }
    }
}
