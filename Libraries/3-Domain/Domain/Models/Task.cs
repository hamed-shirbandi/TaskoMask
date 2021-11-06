using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Models
{
    public class Task : BaseEntity
    {
        #region Properties


        public string Title { get; set; }
        public string Description { get; set; }
        public string CardId { get; set; }


        #endregion
    }
}