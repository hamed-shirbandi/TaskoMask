using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Membership.Entities
{
    /// <summary>
    /// opertors of admin panel
    /// </summary>
    public class Operator : BaseEntity
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string[] RolesId { get; set; }


    }
}
