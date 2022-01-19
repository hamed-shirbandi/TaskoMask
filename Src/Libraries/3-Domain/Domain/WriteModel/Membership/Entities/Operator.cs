using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Membership.Entities
{
    /// <summary>
    /// opertors of admin panel
    /// </summary>
    public class Operator : BaseEntity
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">shared key with User in authentication BC</param>
        public Operator(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(id)));

            base.SetId(id);
        }

        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string[] RolesId { get; set; }


    }
}
