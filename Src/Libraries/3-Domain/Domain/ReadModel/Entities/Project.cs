using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.ReadModel.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string OrganizationId { get; set; }

    }
}
