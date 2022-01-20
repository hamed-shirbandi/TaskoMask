using TaskoMask.Domain.Core.Models;


namespace TaskoMask.Domain.WriteModel.Membership.Entities
{
    public class Permission : BaseEntity
    {
        public string DisplayName { get; set; }
        public string SystemName { get; set; }
        public string GroupName { get; set; }

    }
}
