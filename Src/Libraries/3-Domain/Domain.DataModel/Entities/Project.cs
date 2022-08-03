using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.DataModel.Entities
{
    public class Project : BaseEntity
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id Must sync with write side DB</param>
        public Project(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(id)));

            base.SetId(id);
        }


        public string Name { get; set; }
        public string Description { get; set; }
        public string OrganizationId { get; set; }
        public string OwnerId { get; set; }


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
