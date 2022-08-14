using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using MongoDB.Bson;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            SetId(ObjectId.GenerateNewId().ToString());
        }

        public string UserName { get; set; }

        /// <summary>
        /// If user is active then can login and access to panel
        /// </summary>
        public bool IsActive { get; set; }
        public string PasswordHash { get;  set; }
        public string PasswordSalt { get;  set; }
        public UserType Type { get; set; }

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
