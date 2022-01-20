using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.ReadModel.Entities
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CardId { get; set; }
        public string BoardId { get; set; }
        public string ProjectId { get; set; }
        public string OrganizationId { get; set; }
    }
}
