using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.ReadModel.Entities
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
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(id)));

            base.SetId(id);
        }


        public string Name { get;  set; }
        public string Description { get;  set; }
        public string OwnerId { get; set; }

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
