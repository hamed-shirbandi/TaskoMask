using System;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using MongoDB.Bson;

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
        public Operator()
        {
            SetId(ObjectId.GenerateNewId().ToString());

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
