using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.WriteModel.Membership.Entities
{
    /// <summary>
    /// Roles to determine operator's access level
    /// </summary>
    public class Role : BaseEntity
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string[] PermissionsId { get; set; }

        #region Update private properties

        public void SetAsDeleteed()
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
