using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Tasks.Read.Api.Domain
{
    public class Task : BaseEntity
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id Must sync with write side DB</param>
        public Task(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(id)));

            base.SetId(id);
        }


        public string Title { get; set; }
        public string Description { get; set; }
        //TODO set CardName on publishing related events from the write side
        public string CardName { get; set; }
        public string CardId { get; set; }
        public string BoardId { get; set; }
        public string ProjectId { get; set; }
        public string OrganizationId { get; set; }
        public string OwnerId { get; set; }
        public BoardCardType CardType { get; set; }

        #region Update private properties

        public void SetAsUpdated()
        {
            base.UpdateModifiedDateTime();
        }

        #endregion
    }
}
