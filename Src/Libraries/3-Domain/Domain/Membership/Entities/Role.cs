using TaskoMask.Domain.Core.Models;


namespace TaskoMask.Domain.Membership.Entities
{
    /// <summary>
    /// Roles to determine operator's access level
    /// </summary>
    public class Role : BaseAggregate
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string[] PermissionsId { get; set; }
        protected override void CheckInvariants()
        {
            throw new System.NotImplementedException();
        }
    }
}
