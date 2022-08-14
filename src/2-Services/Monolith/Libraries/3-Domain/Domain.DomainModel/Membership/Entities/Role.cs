using MongoDB.Bson;
using System;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities
{
    /// <summary>
    /// Roles to determine operator's access level
    /// </summary>
    public class Role : BaseEntity
    {
        public Role()
        {
            SetId(ObjectId.GenerateNewId().ToString());

            PermissionsId = Array.Empty<string>();
        }

        public string Name { get;  set; }
        public string Description { get;  set; }
        public string[] PermissionsId { get; set; }

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
