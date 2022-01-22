using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.ReadModel.Entities
{
    /// <summary>
    /// Owners are those who manage their tasks in this system
    /// </summary>
    public class Owner : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id Must sync with write side DB</param>
        public Owner(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(id)));
            
            base.SetId(id);
        }

        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
