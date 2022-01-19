using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.ReadModel.Entities
{
    /// <summary>
    /// Owners are those who manage their tasks in this system
    /// </summary>
    public class Owner : BaseEntity
    {
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
