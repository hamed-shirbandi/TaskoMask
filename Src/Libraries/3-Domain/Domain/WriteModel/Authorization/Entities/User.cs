using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.WriteModel.Authorization.Entities
{
    public class User : BaseEntity
    {

        public string UserName { get; set; }

        /// <summary>
        /// Can log in and access to panel
        /// </summary>
        public bool IsActive { get; set; }
        public string PasswordHash { get;  set; }
        public string PasswordSalt { get;  set; }

    }
}
