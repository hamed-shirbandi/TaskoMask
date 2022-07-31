using System;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.WriteModel.Membership.Entities
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
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Id)));

            base.SetId(id);

            RolesId = Array.Empty<string>();
        }

        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string[] RolesId { get; set; }

        #region Update private properties

        public void SetAsDeleted()
        {
            base.Delete();
            SetAsUpdated();
        }


        public void SetAsRecycled()
        {
            base.Recycle();
            SetAsUpdated();
        }

        public void SetAsUpdated()
        {
            base.UpdateModifiedDateTime();
        }

        #endregion
    }
}
