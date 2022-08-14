using System;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities
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
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Id)));

            base.SetId(id);

            RolesId = Array.Empty<string>();
        }

        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string[] RolesId { get; set; }

        #region Update private properties

        public void SetAsDeleted()
        {
           
            SetAsUpdated();
        }


        public void SetAsRecycled()
        {
            
            SetAsUpdated();
        }

        public void SetAsUpdated()
        {
            base.UpdateModifiedDateTime();
        }

        #endregion
    }
}
