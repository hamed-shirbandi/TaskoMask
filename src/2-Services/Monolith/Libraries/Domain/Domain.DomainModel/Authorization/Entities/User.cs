using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Enums;

namespace TaskoMask.Domain.DomainModel.Authorization.Entities
{
    public class User : BaseEntity
    {

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
