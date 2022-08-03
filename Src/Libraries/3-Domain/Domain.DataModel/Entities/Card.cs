using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.DataModel.Entities
{
    public class Card : BaseEntity
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id Must sync with write side DB</param>
        public Card(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(id)));

            base.SetId(id);
        }


        public string Name { get; set; }
        public BoardCardType Type { get; set; }
        public string BoardId { get; set; }
        public string OrganizationId { get; set; }
        public string OwnerId { get; set; }


        #region Update private properties


        public void SetAsUpdated()
        {
            base.UpdateModifiedDateTime();
        }

        #endregion
    }
}
