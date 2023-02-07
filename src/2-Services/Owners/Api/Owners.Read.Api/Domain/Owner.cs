using System;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Owners.Read.Api.Domain
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
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(id)));
            
            base.SetId(id);
        }

        public string DisplayName { get; set; }
        public string Email { get; set; }

        #region Update private properties

        public void SetAsUpdated()
        {
            base.UpdateModifiedDateTime();
        }

        #endregion
    }
}
