using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;


namespace TaskoMask.Domain.Membership.Entities
{
    public class Permission : BaseAggregate
    {
        public string DisplayName { get; set; }
        public string SystemName { get; set; }
        public string GroupName { get; set; }

        protected override void CheckInvariants()
        {
            throw new System.NotImplementedException();
        }
    }
}
