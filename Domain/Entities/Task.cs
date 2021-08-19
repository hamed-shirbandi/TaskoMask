using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Entities
{
    [Display(Name = nameof(DomainMetadata.Task), ResourceType = typeof(DomainMetadata))]
    public class Task : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Task()
        {

        }

        #endregion

        #region Properties

        public string Title { get; set; }
        public string Description { get; set; }
        public string CardId { get; set; }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion

    }
}
