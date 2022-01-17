using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;


namespace TaskoMask.Domain.Ownership.Entities
{
    public class Permission : BaseEntity
    {
        public string DisplayName { get; set; }
        public string SystemName { get; set; }
        public string GroupName { get; set; }

    }
}
