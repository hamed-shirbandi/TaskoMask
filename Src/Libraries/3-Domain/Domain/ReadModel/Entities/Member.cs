
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.ReadModel.Entities
{
    /// <summary>
    /// Member of a board
    /// </summary>
    public class Member : BaseEntity
    {
        public string OwnerId { get; set; }
        public string BoardId { get; set; }
        public string ProjectId { get; set; }
        public string OrganizationId { get; set; }
        public string AccessLevel { get; set; }
    }

}
