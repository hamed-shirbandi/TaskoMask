using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.WriteModel.Authorization.Entities
{
    public class User : BaseEntity
    {

        public string UserName { get; set; }

        /// <summary>
        /// Can login and access to panel
        /// </summary>
        public bool IsActive { get; set; }
        public string PasswordHash { get;  set; }
        public string PasswordSalt { get;  set; }


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
