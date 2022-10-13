using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Owners.Read.Api.Domain
{
    public class Organization : BaseEntity
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id Must sync with write side DB</param>
        public Organization(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(id)));

            base.SetId(id);
        }


        public string Name { get;  set; }
        public string Description { get;  set; }
        public string OwnerId { get; set; }

        #region Update private properties

        public void SetAsUpdated()
        {
            base.UpdateModifiedDateTime();
        }

        #endregion
    }
}
