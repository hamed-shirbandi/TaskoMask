using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.DataModel.Entities
{
    /// <summary>
    /// Every board's member can leave comment on tasks
    /// </summary>
    public class Comment : BaseEntity
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id Must sync with write side DB</param>
        public Comment(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(id)));

            base.SetId(id);
        }


        public string Content { get; set; }
        public string TaskId { get; set; }


        #region Update private properties


        #endregion

    }
}
