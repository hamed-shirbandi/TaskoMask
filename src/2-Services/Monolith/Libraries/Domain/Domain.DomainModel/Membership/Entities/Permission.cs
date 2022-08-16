using MongoDB.Bson;
using System;
using TaskoMask.BuildingBlocks.Domain.Models;


namespace TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities
{
    public class Permission : BaseEntity
    {
        public Permission()
        {
            SetId(ObjectId.GenerateNewId().ToString());
        }
        public string DisplayName { get; set; }
        public string SystemName { get; set; }
        public string GroupName { get; set; }

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
